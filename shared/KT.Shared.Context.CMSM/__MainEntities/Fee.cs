using KT.Shared.Context.CMSM.Inc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(Fee))]
    public class Fee : KTWrapMongoEntity
    {
        public ObjectId OrganizationId { get; set; }

        public string FeeSetNumber { get; set; }

        public string FeeName { get; set; }

        public double Title { get; set; }

        public double Escrow { get; set; }

        public double Appraisal { get; set; }

        public double Origination { get; set; }

        public double Discount { get; set; }

        public double Total { get; set; }
        
        public List<FeeSet> FeeSets { get; set; }

        public List<RuleItem> FeeRules { get; set; } = new List<RuleItem>();

        [BsonIgnoreIfNull]
        public int[] CompensationGroupTypes { get; set; }

        public double Lender { get; set; }
    }

}
