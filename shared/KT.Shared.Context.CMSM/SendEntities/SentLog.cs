using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM.SendEntities
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(SentLog))]
    public abstract partial class SentLog : KTWrapMongoEntity
    {
        public int Type { get; set; }

        public string CallerIpAddress { get; set; }

        public string ClientApiKey { get; set; }

        public ObjectId ClientId { get; set; }

        public string ClientSettingName { get; set; }

        public ObjectId SettingId { get; set; }

        public bool Success { get; set; }

        [BsonIgnoreIfNull]
        public BsonDocument Metadata { get; set; }
    }

    [BsonDiscriminator(Required = true)]
    [BsonKnownTypes(typeof(SentEmail), typeof(SentSms))]
    public abstract partial class SentLog
    {
        [Serializable]
        [BsonDiscriminator(nameof(SentEmail), Required = true)]
        public class SentEmail : SentLog
        {
            public string From { get; set; }

            public string To { get; set; }

            public string Cc { get; set; }

            public string Bcc { get; set; }

            public string Subject { get; set; }

            public string Body { get; set; }

            public ProviderMessageInfo ProviderMessage { get; set; }

            [Serializable]
            public class ProviderMessageInfo
            {
                public string Provider { get; set; }

                public string MessageId { get; set; }

                public List<ProviderMessageEvent> MessageEvents { get; set; } = new List<ProviderMessageEvent>();
            }

            [Serializable]
            public class ProviderMessageEvent
            {
                public string Name { get; set; }

                public string Email { get; set; }

                public DateTime Date { get; set; }

                [BsonIgnoreIfNull]
                public BsonDocument Metadata { get; set; }
            }
        }

        [Serializable]
        [BsonDiscriminator(nameof(SentSms), Required = true)]
        public class SentSms : SentLog
        {
            public string FromNumber { get; set; }

            public string ToNumber { get; set; }

            public string Message { get; set; }
        }
    }
}
