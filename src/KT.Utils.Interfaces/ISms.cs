namespace KT.Utils.Interfaces;

public interface ISms
{
    Task<SendSmsResponse> SendAsync(SmsSetting setting, SendSmsRequest request);
}

[Serializable]
public class SendSmsRequest
{
    public string FromNumber { get; set; }

    public string ToNumber { get; set; }

    public string Message { get; set; }

    /// <summary>
    /// default: US
    /// </summary>
    public string CountryCode { get; set; } = "US";
}

[Serializable]
public class SendSmsResponse
{
    public SmsVendorType Vendor { get; set; }

    public string Error { get; set; }

    public bool Success { get; set; }

    public string MessageId { get; set; }

    public string MessageStatus { get; set; }

    public string MessageJson { get; set; }

    public object Metadata { get; set; }
}

public enum SmsVendorType
{
    Twilio
}

public class TwilioSmsSetting : SmsSetting
{
    public string AccountSid { get; set; }

    public string AuthToken { get; set; }

    public static TwilioSmsSetting Default => new() { UseAppSetting = true };
}

public abstract class SmsSetting
{
    internal bool UseAppSetting { get; set; }
}
