using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Net;

namespace KT.Utils.Sms;

internal static class TwilioProvider
{
    public static async Task<SendSmsResponse> SendAsync(TwilioSmsSetting setting, SendSmsRequest request)
    {
        var response = new SendSmsResponse { Vendor = SmsVendorType.Twilio };
        var currentSecurityProtocol = ServicePointManager.SecurityProtocol;

        try
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var message = await MessageResource.CreateAsync
            (
                from: new PhoneNumber(PhoneAreaHelper.NormalizePhone(request.FromNumber, request.CountryCode)),
                to: new PhoneNumber(PhoneAreaHelper.NormalizePhone(request.ToNumber, request.CountryCode)),
                body: request.Message,
                client: CreateRestClient(setting)
            );

            response.Metadata = message;

            if (!string.IsNullOrWhiteSpace(message.ErrorMessage))
            {
                response.Error = message.ErrorMessage;
                return response;
            }

            response.Success = ";QUEUED;SENDING;SENT;".Contains(";" + message.Status.ToString().ToUpper() + ";");
            response.MessageId = message.Sid;
            response.MessageStatus = message.Status.ToString();
            response.MessageJson = message.AsJson();
        }
        catch (Exception ex)
        {
            response.Error = ex.Message;
        }
        finally
        {
            ServicePointManager.SecurityProtocol = currentSecurityProtocol;
        }

        return response;
    }

    private static TwilioRestClient CreateRestClient(TwilioSmsSetting setting) => new(setting.AccountSid, setting.AuthToken);
}
