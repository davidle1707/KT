using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM.LogEntities
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(QueueJob))]
    public class QueueJob : KTWrapMongoEntity
    {
        public ObjectId? OrganizationId { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// true -> not run in hosted-service
        /// </summary>
        public bool IsManually { get; set; }

        public BsonDocument Metadata { get; set; }

        public string DescDisplay { get; set; }

        [BsonIgnoreIfNull]
        public DateTime? StartedDate { get; set; }

        [BsonIgnoreIfNull]
        public string StartedDescription { get; set; }

        [BsonIgnoreIfDefault]
        public bool IsError { get; set; }

        [BsonIgnoreIfDefault]
        public string BatchName { get; set; }

        [BsonIgnoreIfDefault]
        public string GroupName { get; set; }

        [BsonIgnoreIfDefault]
        public DateTime? GroupDate { get; set; }
    }
}
