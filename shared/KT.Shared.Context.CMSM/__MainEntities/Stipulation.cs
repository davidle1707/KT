using KT.Shared.Context.CMSM.Inc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(Stipulation))]
    public class Stipulation : KTWrapMongoEntity, IIdName
	{
        public string Name { get; set; }

        public ObjectId OrganizationId { get; set; }

        public string Investor { get; set; }

        public string GuidlineName { get; set; }

        public bool IsActive { get; set; }

        public string RefNumber { get; set; }

        public List<ObjectId> ApplyToProductIds { get; set; } = new List<ObjectId>();

        public List<StipulationCondition> Conditions { get; set; } = new List<StipulationCondition>();

        public string AddToUWConditionCategoryType { get; set; }
    }

    [Serializable]
    public class StipulationCondition : RuleItem
    {
        public int CategoryId { get; set; }

        public bool IsUnderwritingCheckList { get; set; }

        public List<string> Messages { get; set; } = new List<string>();
    }
}
