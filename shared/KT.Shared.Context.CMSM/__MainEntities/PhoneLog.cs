using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(PhoneLog))]
    public abstract partial class PhoneLog : KTWrapMongoEntity
    {
        public ObjectId? OrganizationId { get; set; }

        public ObjectId? UserId { get; set; }

        public ObjectId? FileId { get; set; }

        public int? FromVendor { get; set; }

        public string FromSource { get; set; }

        public ObjectId? FromSourceId { get; set; }

        public bool IsNotifyUser { get; set; }

        public string FromNumber { get; set; }

        public string ToNumber { get; set; }
    }

    [BsonDiscriminator(Required = true)]
    [BsonKnownTypes(typeof(SmsLog), typeof(CallLog))]
    public abstract partial class PhoneLog
    {
        #region Sms

        [Serializable]
        [BsonDiscriminator(nameof(SmsLog), Required = true)]
        public class SmsLog : PhoneLog
        {
            public string Content { get; set; }

            public string SmsId { get; set; }

            public decimal? SmsPrice { get; set; }

            public string SmsJson { get; set; }

            public string Direction { get; set; }

            public string ConversationId { get; set; }
        }

        #endregion

        #region Call

        [Serializable]
        [BsonDiscriminator(nameof(CallLog), Required = true)]
        public class CallLog : PhoneLog
        {
            public string ApiLink { get; set; }

            public string ReponseContent { get; set; }
        }

        #endregion
    }
}
