namespace KT.Utils.Sms;

public class SmsImp : ISms
{
    private readonly IAppSetting _appSetting;

    public SmsImp(IAppSetting appSetting)
    {
        _appSetting = appSetting;
    }

    public async Task<SendSmsResponse> SendAsync(SmsSetting setting, SendSmsRequest request)
    {
        switch (setting)
        {
            case TwilioSmsSetting twilio:
                if (twilio.UseAppSetting)
                {
                    twilio.AccountSid = _appSetting["Sms:Twilio:AccountSid"];
                    twilio.AuthToken = _appSetting["Sms:Twilio:AuthToken"];
                }

                return await TwilioProvider.SendAsync(twilio, request);

            default:
                throw new Exception("Setting is not support");
        }
    }
}
