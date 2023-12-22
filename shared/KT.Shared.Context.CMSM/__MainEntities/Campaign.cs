using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(Campaign))]
    public class Campaign : KTWrapMongoEntity, IIdName
    {
        public ObjectId OrganizationId { get; set; }

        public ObjectId? BranchId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public DateTime EffectiveDate { get; set; }

        public float MarketingAmount { get; set; }

        public string MarketingPhoneNumber { get; set; }

        public bool IsDefault { get; set; }

        public int? MailerNumber { get; set; }

        public string CampaignType { get; set; }

        public ObjectId? NotifyBorrowerTemplateId { get; set; }

        public List<ObjectId> Users { get; set; } = new List<ObjectId>();

        public bool HasNotifyOwner { get; set; }

        public ObjectId? NotifyOwnerTemplateId { get; set; }

        public bool HasNotifyBorrower { get; set; }

        public string NotifyEmails { get; set; }
    }
}
