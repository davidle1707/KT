using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(DashboardCampaignSetting))]
    public class DashboardCampaignSetting : KTWrapMongoEntity
    {
        public ObjectId OrganizationId { get; set; }

        public int BusinessType { get; set; }

        public List<DashboardCampaignDisplayStageSetting> DisplayStages { get; set; } = new List<DashboardCampaignDisplayStageSetting>();
    }

    [Serializable]
    public class DashboardCampaignDisplayStageSetting
    {
        public DashboardCampaignDisplayStageSetting()
        {
            StatusIds = new List<ObjectId>();
        }

        public ObjectId StageId { get; set; }

        public List<ObjectId> StatusIds { get; set; }
    }
}