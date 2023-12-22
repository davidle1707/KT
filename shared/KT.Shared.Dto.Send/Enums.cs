using System;
using System.Collections.Generic;
using System.Text;

namespace KT.Shared.Dto.Send
{
    [Serializable]
    public enum SettingType
    {
        Sms,

        Email,
    }

    [Serializable]
    public enum OtpMethod
    {
        Sms,

        Email,

        SmsAndEmail,
    }

    [Serializable]
    public enum SentLogType
    {
        Sms,

        Email,
    }

    [Serializable]
    public enum OtpTransactionStatus
    {
        Verifying = 0,

        Succeed = 1,

        Invalid = 2,

        MaxFailed = 3,

        Expired = 4,

        Resend = 5,

        NotMatch = 6
    }
}
