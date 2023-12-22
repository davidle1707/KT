using System;
using System.Collections.Generic;
using System.Text;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public class OrgPhoneSetting
    {
        public bool EnableSms { get; set; }

        public int SmsVendorType { get; set; } = 1;

        public bool EnableCall { get; set; }

        public int CallVendorType { get; set; } = 2;

        public PhoneTwilio Twilio { get; set; }

        public PhoneClick2Call Click2Call { get; set; }

        public PhoneIntermedia Intermedia { get; set; }

    }

    [Serializable]
    public class PhoneTwilio : PhoneVendor
    {
        public string AccountSid { get; set; }

        public string AuthToken { get; set; }
    }

    [Serializable]
    public class PhoneClick2Call : PhoneVendor
    {
        public string AuthKey { get; set; }

        public string AuthUser { get; set; }

        public bool IsAutoAnswer { get; set; }

        public bool IsRecording { get; set; }

        public string RingBack { get; set; }

        public string SrcCidName { get; set; }

        public string SrcCidNumber { get; set; }
    }

    [Serializable]
    public class PhoneIntermedia : PhoneVendor
    {
        public string Token { get; set; }
    }

    [Serializable]
    public class PhoneVendor
    {
        public bool IsActive { get; set; }

        public string APIUrl { get; set; }

        public string APIVersion { get; set; }

        public string DefaultNumber { get; set; }

        public string ApplicationId { get; set; }
    }

    [Serializable]
    public class UserPhoneSetting
    {
        public bool EnableSms { get; set; }

        public string SmsDefaultPhone { get; set; }

        public bool EnableCall { get; set; }

        public string CallDefaultPhone { get; set; }

        public string CallDestCidName { get; set; }

        public string CallDestCidNumber { get; set; }

        public string CallSrcCidNumber { get; set; }

        public string CallSrcCidName { get; set; }
    }
}
