using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM.NotificationEntities
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(Message))]
    public class Message : KTWrapMongoEntity
    {
        public int ForType { get; set; }

        public string ForTypeName { get; set; }

        public ObjectId? ForId { get; set; }

        public int Priority { get; set; }

        public bool IsDismissed { get; set; }

        public bool IsRead { get; set; }

        public string Title { get; set; }

        [BsonIgnoreIfNull]
        public BsonDocument Metadata { get; set; }
    }
}
