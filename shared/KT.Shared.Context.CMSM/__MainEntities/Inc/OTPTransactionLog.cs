using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public class OTPTransactionLog
    {
        public ObjectId Id { get; set; }

        public DateTime LoggedDate { get; set; }

        public int Status { get; set; }

        public string OTP { get; set; }

        public OTPSetting Setting { get; set; }

        public string SentToSmsNumber { get; set; }

        public string SentToEmailAddress { get; set; }

        public List<OTPVerifyLog> Verifies { get; set; } = new List<OTPVerifyLog>();
    }

    public class OTPVerifyLog
    {
        public string OTP { get; set; }

        public bool IsSuccess { get; set; }

        public string Description { get; set; }

        public DateTime LoggedDate { get; set; }
    }
}
