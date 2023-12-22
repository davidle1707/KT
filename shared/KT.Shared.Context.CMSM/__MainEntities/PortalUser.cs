using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(PortalUser))]
    public class PortalUser : KTWrapMongoEntity
    {
        public ObjectId OrganizationId { get; set; }

        public ObjectId BusinessFileId { get; set; }

        public int BorrowerIndex { get; set; }

        public bool BorrowerSpouse { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string TimeZoneId { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public ObjectId? OTPTransactionId { get; set; }

        public bool EnableOTP { get; set; }

        public bool IsUserAllowOTP { get; set; }

        public int OTPMethod { get; set; }

        public PortalUser Clone() => (PortalUser)this.MemberwiseClone();
    }
}
