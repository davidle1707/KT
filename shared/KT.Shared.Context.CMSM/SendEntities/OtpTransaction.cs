using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace KT.Shared.Context.CMSM.SendEntities
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(OtpTransaction))]
    public partial class OtpTransaction : KTWrapMongoEntity
    {
        public string CallerIpAddress { get; set; }

        public string IpAddress { get; set; }

        public ObjectId ClientId { get; set; }

        public string ClientApiKey { get; set; }

        public string ClientSettingName { get; set; }

        public int Status { get; set; }

        public string Otp { get; set; }

        public OTPSetting Setting { get; set; }

        public string SentToSmsNumber { get; set; }

        public string SentToEmailAddress { get; set; }

        public List<OtpVerify> Verifies { get; set; } = new List<OtpVerify>();

        public ObjectId? SentSmsLogId { get; set; }

        public ObjectId? SentEmailLogId { get; set; }
    }

    public partial class OtpTransaction
    {
        [Serializable]
        public class OtpVerify
        {
            public string Otp { get; set; }

            public bool IsSuccess { get; set; }

            public string Description { get; set; }

            public string IpAddress { get; set; }

            public string CallerIpAddress { get; set; }

            public DateTime Date { get; set; }
        }
    }
}
