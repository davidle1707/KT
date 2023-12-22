using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM.Inc
{
    [Serializable]
    public class RateDetail : KTWrapMongoEntityId
    {
        public double TodayRate { get; set; }

        public double FifteenDaysLockPoints { get; set; }

        public double ThirtyDaysLockPoints { get; set; }

        public double FortyFiveDaysLockPoints { get; set; }

        public double SixtyDaysLockPoints { get; set; }

        public double TodayPrice { get; set; }

    }

    [Serializable]
    public abstract class RateTableItem : KTWrapMongoEntityId
    {
        public bool Enable { get; set; }

        public DateTime? ImportedDate { get; set; }

        public string ImportedTransactionId { get; set; }

        public string ImportedNote { get; set; }
    }

    #region SRP

    [Serializable]
    public class RateSRPTable
    {
        public List<RateSRPItem> Items { get; set; } = new List<RateSRPItem>();
    }

    [Serializable]
    public class RateSRPItem : RateTableItem
    {
        [BsonIgnoreIfNull]
        public string State { get; set; }

        [BsonIgnoreIfNull, BsonRepresentation(BsonType.Decimal128)]
        public decimal? LoanAmountFrom { get; set; }

        [BsonIgnoreIfNull, BsonRepresentation(BsonType.Decimal128)]
        public decimal? LoanAmountTo { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal SRPValue { get; set; }
    }

    #endregion

    #region Adjustment

    [Serializable]
    public class RateAdjustmentTable
    {
        public List<RateAdjustmentItem> Items { get; set; } = new List<RateAdjustmentItem>();
    }

    [Serializable]
    public class RateAdjustmentItem : RateTableItem
    {
        [BsonIgnoreIfNull]
        public string Description { get; set; }

        [BsonIgnoreIfNull]
        public string StatusText { get; set; }

        public bool IsDisplay { get; set; }

        public List<DynamicCondition> Conditions { get; set; } = new List<DynamicCondition>();

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal AdjustValue { get; set; }
    }

    #endregion

    #region Profit

    [Serializable]
    public class RateProfitTable
    {
        public List<RateProfitItem> Items { get; set; } = new List<RateProfitItem>();
    }

    [Serializable]
    public class RateProfitItem : RateAdjustmentItem
    {
    }

    #endregion

    #region Daily

    [Serializable]
    public class RateDailyTable
    {
        public List<RateDailyItem> Items { get; set; } = new List<RateDailyItem>();
    }

    [Serializable]
    public class RateDailyItem : RateTableItem
    {
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Rate { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }
    }

    #endregion
}
