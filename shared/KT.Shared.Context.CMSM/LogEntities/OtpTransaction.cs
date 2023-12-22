using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM.LogEntities
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(OtpTransaction))]
    public partial class OtpTransaction : KTWrapMongoEntity
    {
        public ObjectId OrganizationId { get; set; }

        public string IpAddress { get; set; }

        public int ForType { get; set; }

        public ObjectId ForId { get; set; }

        public int Status { get; set; }

        public string OTP { get; set; }

        public OTPSetting Setting { get; set; }

        public string SentToSmsNumber { get; set; }

        public string SentToEmailAddress { get; set; }

        public List<OtpVerify> Verifies { get; set; } = new List<OtpVerify>();
    }

    public partial class OtpTransaction
    {
        public class OtpVerify
        {
            public string OTP { get; set; }

            public bool IsSuccess { get; set; }

            public string Description { get; set; }

            public string IpAddress { get; set; }

            public DateTime Date { get; set; }
        }
    }
}
