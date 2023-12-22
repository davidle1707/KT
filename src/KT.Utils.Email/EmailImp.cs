using System.Net;
using System.Net.Mail;

namespace KT.Utils.Email;

public partial class EmailImp : IEmail
{
    private readonly ILog _log;

    public EmailImp(ILog log)
    {
        _log = log;
    }

    public async Task<SendEmailResponse> SendAsync(SendEmailRequest request)
    {
        if (request.Setting.IsSendGrid)
        {
            return await SendBySendGridAsync(request);
        }

        return await SendBySmtpClientAsync(request);
    }

    public async Task<SendGridSendBatchResponse> SendPerRecipientAsync(SendEmailRequest request)
    {
        if (request.Setting.IsSendGrid)
        {
            return await SendPerRecipientBySendGridAsync(request);
        }

        var response = await SendBySmtpClientAsync(request);

        return new SendGridSendBatchResponse { Batches = { (new List<string>(), response) } };
    }

    public async Task<SendEmailResponse> SendBySmtpClientAsync(SendEmailRequest request)
    {
        var taskSend = Task.Factory.StartNew(Send);

        if (request.IsSendBackground)
        {
            return new SendEmailResponse();
        }

        await taskSend;

        return new SendEmailResponse
        {
            Error = await taskSend ? null : "Have error in while processing send email"
        };

        bool Send()
        {
            try
            {
                if (string.IsNullOrEmpty(request.Message.From?.Address))
                {
                    request.Message.From = new MailAddress((string.IsNullOrWhiteSpace(request.Setting.From) ? request.Setting.UserName : request.Setting.From), request.Setting.FullName);
                }

                if (request.Message.Sender == null)
                {
                    request.Message.Sender = request.Message.From;
                }

                var client = new SmtpClient(request.Setting.Server)
                {
                    EnableSsl = request.Setting.EnableSsl,
                    Port = request.Setting.Port,
                    Credentials = new NetworkCredential(request.Setting.UserName, request.Setting.Password)
                };

                client.Send(request.Message);

                return true;
            }
            catch (Exception ex)
            {
                _log.Error(ex, $"{nameof(SendBySmtpClientAsync)}: {ex.Message}");
                return false;
            }
        }
    }
}