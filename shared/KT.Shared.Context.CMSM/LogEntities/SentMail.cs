using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM.LogEntities
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(SentMail))]
    public partial class SentMail : KTWrapMongoEntity
    {
        public ObjectId OrgId { get; set; }

        public int ForType { get; set; }

        public ObjectId? ForId { get; set; }

        [BsonIgnoreIfNull]
        public string BatchName { get; set; }

        [BsonIgnoreIfNull]
        public string GroupName { get; set; }

        [BsonIgnoreIfNull]
        public DateTime? GroupDate { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        [BsonIgnoreIfNull]
        public string Cc { get; set; }

        [BsonIgnoreIfNull]
        public string Bcc { get; set; }

        public string Subject { get; set; }

        [BsonIgnoreIfNull]
        public string Body { get; set; }

        [BsonIgnoreIfNull]
        public BsonDocument Metadata { get; set; }

        [BsonIgnoreIfNull]
        public ProviderMessageInfo ProviderMessage { get; set; }

        [BsonIgnoreIfNull]
        public SendEmailAction Action { get; set; }
    }

    public partial class SentMail
    {
        [Serializable]
        public class ProviderMessageInfo
        {
            public string Provider { get; set; }

            public string MessageId { get; set; }

            public List<ProviderMessageEvent> MessageEvents { get; set; } = new List<ProviderMessageEvent>();

            public List<ProviderMessageNotifyEvent> NotifyEvents { get; set; } = new List<ProviderMessageNotifyEvent>();
        }

        [Serializable]
        public class ProviderMessageEvent
        {
            public string Name { get; set; }

            [BsonIgnoreIfNull]
            public string Email { get; set; }

            public DateTime Date { get; set; }

            [BsonIgnoreIfNull]
            public BsonDocument Metadata { get; set; }
        }

        [Serializable]
        public class ProviderMessageNotifyEvent
        {
            public string Event { get; set; }

            public DateTime NotifyDate { get; set; }
        }
    }

    [Serializable]
    [KTWrapMongoCollectionName(typeof(SentMailBody))]
    public partial class SentMailBody : KTWrapMongoEntity
    {
        [BsonIgnoreIfNull]
        public string GroupId { get; set; }
    }
}
