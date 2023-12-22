using System.Net.Mail;

namespace KT.Utils.Interfaces;

public interface IEmail
{
    Task<SendEmailResponse> SendAsync(SendEmailRequest request);

    Task<SendGridSendBatchResponse> SendPerRecipientAsync(SendEmailRequest request);

    Task<SendEmailResponse> SendBySendGridAsync(SendEmailRequest request);

    Task<SendEmailResponse> SendBySmtpClientAsync(SendEmailRequest request);
}

[Serializable]
public class SendEmailResponse
{
    public bool Success => string.IsNullOrWhiteSpace(Error);

    public string Error { get; set; }

    public string MessageId { get; set; }

    public string MessageStatus { get; set; }

    public object Metadata { get; set; }

    public SendEmailResponse(string error = null)
    {
        Error = error;
    }
}

[Serializable]
public class SendGridSendBatchResponse
{
    public bool Success => string.IsNullOrWhiteSpace(Error);

    public string Error { get; set; }

    public List<(List<string> Emails, SendEmailResponse Response)> Batches { get; set; } = new List<(List<string> Emails, SendEmailResponse Response)>();

    public SendGridSendBatchResponse(string error = null)
    {
        Error = error;
    }
}

[Serializable]
public class SendEmailRequest
{
    public MailMessage Message { get; set; }

    public SendEmailSetting Setting { get; set; }

    public bool IsSendBackground { get; set; }

    public List<EmailAttchmentBase64> Base64Attachments { get; set; } = new List<EmailAttchmentBase64>();

    public EmailTrackingSetting TrackingSetting { get; set; }
}

[Serializable]
public class EmailAttchmentBase64
{
    public string Content { get; set; }

    public string MediaType { get; set; }

    public string FileName { get; set; }

    public string Disposition { get; set; }

    public string ContentId { get; set; }
}

[Serializable]
public class SendEmailSetting
{
    public string From { get; set; }

    public string Server { get; set; }

    public int Port { get; set; }

    public bool EnableSsl { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string FullName { get; set; }

    public bool IsSendGrid => !string.IsNullOrWhiteSpace(Server) && Server.Equals("smtp.sendgrid.com", StringComparison.OrdinalIgnoreCase);
}

[Serializable]
public class EmailTrackingSetting
{
    public bool Open { get; set; }

    public bool Click { get; set; }

    public Dictionary<string, string> Args { get; set; } = new Dictionary<string, string>();

    /// <summary>
    /// get/set args
    /// </summary>
    public string this[string key]
    {
        get => Args.TryGetValue(key, out var outArg) ? outArg : null;
        set => Args[key] = value;
    }

    public bool HasTracking => Open || Click;
}


