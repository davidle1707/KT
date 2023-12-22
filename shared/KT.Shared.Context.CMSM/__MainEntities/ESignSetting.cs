using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(ESignSetting))]
    public abstract partial class ESignSetting : KTWrapMongoEntity
    {

    }

    [BsonDiscriminator(Required = true)]
    [BsonKnownTypes(typeof(GlobalESignSetting), typeof(OrganizationESignSetting), typeof(RequestTypeESignSetting), 
        typeof(DocumentESignSetting), typeof(WebhookESignSetting))]
    public abstract partial class ESignSetting
    {
        [Serializable]
        [BsonDiscriminator(nameof(GlobalESignSetting), Required = true)]
        public class GlobalESignSetting : ESignSetting
        {
            public bool IsSignSequential { get; set; }

            public bool EmailReminders { get; set; }

            public int ReminderPeriodDays { get; set; }

            public int ExpirationDays { get; set; }

            public string TextFont { get; set; }

            public int TextFontSizeInPixel { get; set; }

            public string TextColorInHex { get; set; }

            public bool TextIsBold { get; set; }

            public bool TextIsItalic { get; set; }

        }

        [Serializable]
        [BsonDiscriminator(nameof(OrganizationESignSetting), Required = true)]
        public class OrganizationESignSetting : ESignSetting
        {
            public ObjectId OrganizationId { get; set; }

            public string ClientId { get; set; }

            public string ClientSecret { get; set; }

            public string RedirectUri { get; set; }

            public string RefreshToken { get; set; }

            public bool Active { get; set; }

        }

        [Serializable]
        [BsonDiscriminator(nameof(RequestTypeESignSetting), Required = true)]
        public class RequestTypeESignSetting : ESignSetting
        {
            public ObjectId OrganizationId { get; set; }

            public string TypeId { get; set; }

            public string TypeName { get; set; }

        }

        [Serializable]
        [BsonDiscriminator(nameof(DocumentESignSetting), Required = true)]
        public class DocumentESignSetting : ESignSetting
        {
            public ObjectId OrganizationId { get; set; }

            //public ObjectId? BranchId { get; set; }

            //public int BusinessType { get; set; }

            public string Name { get; set; }

            public ObjectId DocumentId { get; set; }

            public string RequestTypeId { get; set; }

            public List<RecipientESignSetting> Recipients { get; set; }

        }

        [Serializable]
        [BsonDiscriminator(nameof(WebhookESignSetting), Required = true)]
        public class WebhookESignSetting : ESignSetting
        {
            public ObjectId OrganizationId { get; set; }

            public string WebhookId { get; set; }

            public string WebhookUrl { get; set; }

            public string WebhookActions { get; set; }

        }

    }
}
