
using KT.Shared.Context.CMSM.Inc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(RateSheet))]
    public class RateSheet : KTWrapMongoEntity
    {
        public ObjectId OrganizationId { get; set; }

        public int RateSheetNumber { get; set; }

        public string RateSheetName { get; set; }

        public List<RateDetail> RateDetails { get; set; } = new List<RateDetail>();

        public List<RuleItem> RateRules { get; set; } = new List<RuleItem>();

        public DateTime? EffectiveDate { get; set; }

        public bool ShowOriginationPoint { get; set; }

        public int VariationMethodType { get; set; }

        public int VariationSortType { get; set; }

        public int BuyUpFromRate { get; set; }

        public int BuyDownFromRate { get; set; }

        public double IncrementRateBy { get; set; }

        public double DecreaseRateBy { get; set; }

        public double IncrementPriceBy { get; set; }

        public double DecreasePriceBy { get; set; }

        public double IncrementOriginationPointBy { get; set; }

        public double DecreaseOriginationPointBy { get; set; }

        [BsonIgnoreIfNull]
        public int[] CompensationGroupTypes { get; set; }

        [BsonIgnoreIfNull]
        public RateSRPTable SRPTable { get; set; }

        [BsonIgnoreIfNull]
        public RateAdjustmentTable AdjustmentTable { get; set; }

        [BsonIgnoreIfNull]
        public RateProfitTable ProfitTable { get; set; }

        [BsonIgnoreIfNull]
        public RateDailyTable DailyTable { get; set; }

        public double ProfitPerLoan { get; set; }

        public bool Active { get; set; }

        [BsonIgnoreIfNull]
        public int[] PriceExtendValueTypes { get; set; }

        public double? VariationNearestToPriceValue { get; set; }
    }
   
}
