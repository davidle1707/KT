using KT.Common;
using SendGrid.Helpers.Mail;
using SendGrid.Helpers.Reliability;
using System.Net;
using System.Net.Mail;

namespace KT.Utils.Email;

public partial class EmailImp
{
    public async Task<SendEmailResponse> SendBySendGridAsync(SendEmailRequest request)
    {
        var response = new SendEmailResponse();

        if (request.IsSendBackground)
        {
            _ = Task.Factory.StartNew(sendAsync);
            return response;
        }

        await sendAsync();

        return response;

        async Task sendAsync()
        {
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(request.Message.From.Address, request.Message.From.DisplayName),
                Subject = request.Message.Subject,
                HtmlContent = request.Message.Body
            };

            if (request.Message.To.Count == 0 && request.Message.CC?.Count > 0)
            {
                foreach (var cc in request.Message.CC)
                {
                    request.Message.To.Add(cc);
                }

                request.Message.CC.Clear();
            }

            // to
            msg.AddTos(request.Message.To.Select(e => new EmailAddress(e.Address, e.DisplayName)).ToList());

            // cc
            if (request.Message.CC?.Count > 0)
            {
                msg.AddCcs(request.Message.CC.Select(e => new EmailAddress(e.Address, e.DisplayName)).ToList());
            }

            // bcc
            if (request.Message.Bcc?.Count > 0)
            {
                msg.AddBccs(request.Message.Bcc.Select(e => new EmailAddress(e.Address, e.DisplayName)).ToList());
            }

            PopuplateOtherInfosToSendGridMessage(msg, request);

            // setting.Password ~ ApiKey
            await ProcessSendBySendGridAsync(request.Setting.Password, msg);

            if (!response.Success && request.IsSendBackground)
            {
                _log.Error($"{nameof(SendBySendGridAsync)}: {response.Error}");
            }
        }
    }

    public async Task<SendGridSendBatchResponse> SendPerRecipientBySendGridAsync(SendEmailRequest request)
    {
        var batchResponse = new SendGridSendBatchResponse();

        if (request.IsSendBackground)
        {
            _ = Task.Factory.StartNew(sendBatchAsync);
            return batchResponse;
        }

        await sendBatchAsync();

        return batchResponse;

        async Task sendBatchAsync()
        {
            // optimize emails
            var allRecipients = new List<EmailAddress>();
            if (request.Message.To?.Count > 0) allRecipients.AddRange(request.Message.To.Select(a => new EmailAddress(a.Address.ToLower(), a.DisplayName)));
            if (request.Message.CC?.Count > 0) allRecipients.AddRange(request.Message.CC.Select(a => new EmailAddress(a.Address.ToLower(), a.DisplayName)));
            if (request.Message.Bcc?.Count > 0) allRecipients.AddRange(request.Message.Bcc.Select(a => new EmailAddress(a.Address.ToLower(), a.DisplayName)));

            if (allRecipients.Count == 0)
            {
                return;
            }

            allRecipients = allRecipients.GroupBy(a => a.Email).Select(a => a.First()).ToList(); // remove duplicate

            // sent, the total number of recipients must no more than 1000, ref: https://docs.sendgrid.com/api-reference/mail-send/limitations
            foreach (var recipients in allRecipients.Batch(500))
            {
                var msg = new SendGridMessage
                {
                    Personalizations = recipients.Select(recipient => new Personalization { Tos = new List<EmailAddress> { recipient } }).ToList()
                };

                msg.SetFrom(new EmailAddress(request.Message.From.Address, request.Message.From.DisplayName));
                msg.SetGlobalSubject(request.Message.Subject);
                msg.AddContent(MimeType.Html, request.Message.Body);

                PopuplateOtherInfosToSendGridMessage(msg, request);

                var response = await ProcessSendBySendGridAsync(request.Setting.Password, msg); // setting.Password ~ ApiKey
                batchResponse.Batches.Add((msg.Personalizations.SelectMany(a => a.Tos.Select(x => x.Email)).ToList(), response));
            }
        }
    }

    private async Task<SendEmailResponse> ProcessSendBySendGridAsync(string apiKey, SendGridMessage msg)
    {
        var response = new SendEmailResponse();

        try
        {
            var client = new SendGridClient(new SendGridClientOptions
            {
                ApiKey = apiKey,
                ReliabilitySettings = new ReliabilitySettings(1, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(1))
            });

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            var sentResponse = await client.SendEmailAsync(msg);

            response.Metadata = sentResponse;
            response.MessageStatus = sentResponse.StatusCode.ToString();

            if (sentResponse.StatusCode == HttpStatusCode.Accepted || sentResponse.StatusCode == HttpStatusCode.OK)
            {
                if (sentResponse.Headers != null)
                {
                    var headerId = sentResponse.Headers.FirstOrDefault(a => a.Key.Equals("X-Message-Id", StringComparison.OrdinalIgnoreCase));
                    response.MessageId = headerId.Value != null ? string.Join(";", headerId.Value) : "";
                }
            }
            else
            {
                response.Error = $"StatusCode ({sentResponse.StatusCode})";
                if (sentResponse.Body != null)
                {
                    var body = await sentResponse.Body.ReadAsStringAsync();
                    response.Error = $"{response.Error } Body ({body})";
                }
            }
        }
        catch (Exception ex)
        {
            _log.Error(ex, $"{nameof(SendBySendGridAsync)}: {ex.Message}");
            response.Error = ex.Message;
        }

        return response;
    }

    private void PopuplateOtherInfosToSendGridMessage(SendGridMessage msg, SendEmailRequest request)
    {
        // categories
        if (request.Message.Headers?.Count > 0)
        {
            // categories
            var categories = request.Message.Headers.AllKeys.Where(key => key.Equals("Category", StringComparison.OrdinalIgnoreCase)).Select(key => request.Message.Headers[key]).Where(cat => !string.IsNullOrWhiteSpace(cat)).ToList();
            if (categories.Count > 0)
            {
                msg.Categories = categories;
            }
        }

        // attachments
        if (request.Message.Attachments?.Count > 0)
        {
            msg.AddAttachments(request.Message.Attachments.Select(a => new SendGrid.Helpers.Mail.Attachment
            {
                Content = StreamToBase64(a.ContentStream),
                Type = a.ContentType.MediaType,
                Disposition = a.ContentDisposition.DispositionType,
                ContentId = a.ContentId,
                Filename = a.Name
            }));
        }

        // attachments - base64
        if (request.Base64Attachments?.Count > 0)
        {
            msg.AddAttachments(request.Base64Attachments.Select(a => new SendGrid.Helpers.Mail.Attachment
            {
                Content = a.Content,
                Type = a.MediaType,
                Disposition = a.Disposition,
                ContentId = a.ContentId,
                Filename = a.FileName
            }));
        }

        // tracking
        var tracking = request.TrackingSetting ?? new EmailTrackingSetting();
        msg.TrackingSettings = new TrackingSettings
        {
            OpenTracking = new OpenTracking { Enable = tracking.Open },
            ClickTracking = new ClickTracking { Enable = tracking.Click }
        };

        if (tracking.HasTracking && tracking.Args?.Count > 0)
        {
            msg.CustomArgs = tracking.Args;
        }
    }

    private string StreamToBase64(Stream stream)
    {
        using var memoryStream = new MemoryStream();
        stream.CopyTo(memoryStream);
        return Convert.ToBase64String(memoryStream.ToArray());
    }
}
