using System;

namespace KT.Shared.Dto.Send.Inc
{
    [Serializable]
    public class OtpSettingDto
    {
        public OtpMethod Method { get; set; } = OtpMethod.Sms;

        public string MessageFormat { get; set; }

        public bool PwdHasLetter { get; set; }

        public bool PwdHasNumber { get; set; }

        public bool PwdHasSymbol { get; set; }

        public int PwdLength { get; set; }

        public int PwdExpiredMinutes { get; set; }

        public int VerifyPwdFailedTimes { get; set; }
    }
}
