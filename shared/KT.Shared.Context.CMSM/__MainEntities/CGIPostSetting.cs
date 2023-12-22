using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(CGIPostSetting))]
    public class CGIPostSetting : KTWrapMongoEntity, IIdName
    {
        public string Name { get; set; }

        public ObjectId OrganizationId { get; set; }

        public int BusinessType { get; set; }

        public string PostKey { get; set; }

        public bool IsActived { get; set; }

        public ObjectId? BranchId { get; set; }

        public ObjectId? CampaignId { get; set; }

        public ObjectId? DBAId { get; set; }

        public bool UseFixedFields { get; set; }

        public List<CGIPostParam> Params { get; set; }

        public ObjectId? StageId { get; set; }

        public ObjectId? StatusId { get; set; }
    }

    [Serializable]
    public class CGIPostParam : KTWrapMongoEntityId, IIdName
    {
        public string Name { get; set; }

        public bool IsRequired { get; set; }

        public string Description { get; set; }

        public string Value { get; set; }

        public bool IsMapping { get; set; }
    }
}
