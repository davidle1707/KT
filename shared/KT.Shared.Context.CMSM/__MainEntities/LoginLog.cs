using System;
using KT.Shared.Context.CMSM.BA;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(LoginLog))]
    public class LoginLog : KTWrapMongoEntity
    {
        public LoginLog()
        {
            CreatedDate = DateTime.UtcNow;
        }

        public int LogType { get; set; }

        public ObjectId OrganizationId { get; set; }

        [BsonIgnoreIfNull]
        public ObjectId? BranchId { get; set; }

        public ObjectId UserId { get; set; }

        public string IpAddress { get; set; }

        public string UserAgent { get; set; }

        public string Browser { get; set; }

        [BsonIgnoreIfNull]
        public OTPTransactionLog OTPTransaction { get; set; }

        public ObjectId? OtpTransactionId { get; set; }

        [BsonIgnoreIfNull]
        public BorrowerInfo PortalBorrower { get; set; }

        [BsonIgnoreIfNull]
        public int? PortalBorrowerIndex { get; set; }

        [BsonIgnoreIfNull]
        public bool? PortalBorrowerSpouse { get; set; }

        [BsonIgnoreIfNull]
        public int? PortalFileNumber { get; set; }

        [BsonIgnoreIfNull]
        public BrokerCompany BrokerCompany { get; set; }
    }
}
