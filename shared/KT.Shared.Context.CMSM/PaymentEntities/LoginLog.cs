using System;
using MongoDB.Bson;

namespace KT.Shared.Context.CMSM.PaymentEntities
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(LoginLog))]
    public class LoginLog : KTWrapMongoEntity
    {
        public LoginLog()
        {
            CreatedDate = DateTime.UtcNow;
        }

        public ObjectId UserId { get; set; }

        public string IpAddress { get; set; }

        public string UserAgent { get; set; }

        public string Browser { get; set; }

        public ObjectId? OtpTransactionId { get; set; }
    }
}
