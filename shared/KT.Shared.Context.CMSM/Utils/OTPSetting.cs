using System;

namespace KT.Shared.Context
{
	[Serializable]
	public class OTPSetting
	{
        public int Method { get; set; }

        public string MessageFormat { get; set; }

        public bool PwdHasLetter { get; set; }

		public bool PwdHasNumber { get; set; }

		public bool PwdHasSymbol { get; set; }

        public int PwdLength { get; set; }

        public int PwdExpiredMinutes { get; set; }

        public int VerifyPwdFailedTimes { get; set; }
	}
}