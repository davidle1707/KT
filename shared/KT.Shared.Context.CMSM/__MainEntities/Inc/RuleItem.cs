using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM.Inc
{
    [Serializable]
    public class RuleItem : KTWrapMongoEntityId
    {
        public bool Enable { get; set; }

        public string Rule { get; set; }

        [BsonIgnoreIfNull]
        public string Description { get; set; }

        [BsonIgnoreIfNull]
        public string StatusText { get; set; }

        public bool IsDisplay { get; set; }

        [BsonIgnoreIfNull]
        public int? FailType { get; set; }

        [BsonIgnoreIfNull]
        public string FailReason { get; set; }

        public string GroupId { get; set; }
    }
}
