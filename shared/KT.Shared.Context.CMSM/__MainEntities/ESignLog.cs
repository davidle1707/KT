using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(ESignLog))]
    public class ESignLog : KTWrapMongoEntity
    {
        public ObjectId OrganizationId { get; set; }

        public ObjectId DocumentId { get; set; }

        public ObjectId ReferenceId { get; set; }

        public string LastRunStatus { get; set; }

        public string Name { get; set; }

        public string RequestId { get; set; }

        public bool IsInProcess { get; set; }

        //public string RequestTypeId { get; set; }

        //public string RequestTypeName { get; set; }

        public string RequestStatus { get; set; }

        [BsonIgnoreIfNull]
        public DateTime? ExpireBy { get; set; }

        public double SignPercentage { get; set; }

        [BsonIgnoreIfNull]
        public DateTime? LastReminder { get; set; }

        [BsonIgnoreIfNull]
        public DateTime? LastRequestNewESign { get; set; }

        public List<ESignLogAction> Actions { get; set; }

        public List<ESignLogDetail> LogDetails { get; set; }
    }

    [Serializable]
    public class ESignLogDetail : KTWrapMongoEntityId
    {
        public DateTime LogDate { get; set; }

        public string RunStatus { get; set; }

        public string Message { get; set; }

        public string RawJson { get; set; }
    }

    [Serializable]
    public class ESignLogAction
    {
        public string Id { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int Order { get; set; }

        public string Status { get; set; }

    }
}
