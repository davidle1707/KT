using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM.SendEntities
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(Setting))]
    public abstract partial class Setting : KTWrapMongoEntity
    {
        public string Name { get; set; }

        public int Type { get; set; } // Email, Sms

        public bool IsActive { get; set; }
    }

    [BsonDiscriminator(Required = true)]
    [BsonKnownTypes(typeof(EmailSendGrid), typeof(SmsTwilio))]
    public abstract partial class Setting
    {
        [Serializable]
        [BsonDiscriminator(nameof(EmailSendGrid), Required = true)]
        public class EmailSendGrid : Setting
        {
            public string ApiKey { get; set; }
        }

        [Serializable]
        [BsonDiscriminator(nameof(SmsTwilio), Required = true)]
        public class SmsTwilio : Setting
        {
            public string ApiUrl { get; set; }

            public string ApiVersion { get; set; }

            public string AccountSid { get; set; }

            public string AuthToken { get; set; }
           
            public string ApplicationId { get; set; }
        }
    }
}
