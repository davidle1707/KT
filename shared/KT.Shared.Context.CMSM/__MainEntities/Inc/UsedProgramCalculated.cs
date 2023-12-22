using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public partial class UsedProgramCalculated
    {
        public ProductRef ProductRef { get; set; }

        public RateRef RateRef { get; set; }

        public FeeRef FeeRef { get; set; }

        public bool? HighCostPassed { get; set; }

        public double? HighCostPoint { get; set; }

        public double? HighCostTotalFees { get; set; }

        public double CalculatedRate { get; set; }

        public double CalculatedPoint { get; set; }

        public double CalculatedTotalFees { get; set; }

        public double CalculatedPI { get; set; }

        public double CalculatedPITI { get; set; }

        public double CalculatedAPR { get; set; }

        public double CalculatedPrice { get; set; }

        public double OriginalPrice { get; set; } // CalculatedPrice = OriginalPrice + Prices(rules, tables, ...)

        public double CalculatedLLPA { get; set; }

        public double? OverrideRate { get; set; }

        public double? OverridePrice { get; set; }

        public double? OverridePoint { get; set; }

        public double? OverrideTotalFees { get; set; }

        public double? OverrideAPR { get; set; }

        public bool? IsException { get; set; }

        /// <summary>
        /// Use for Dev to know exception from where
        /// </summary>
        public string ExceptionFromSource { get; set; }

        public string ExceptionRefNo { get; set; }

        public string ExceptionNote { get; set; }

        public double? ReqPricingExceptionPrice { get; set; }

        public string ReqPricingExceptionNote { get; set; }

        #region huyngo: 11/07/2021

        public string OverrideType { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal? OverrideValue { get; set; }

        #endregion

    }

    public partial class UsedProgramCalculated
    {
        public List<LLPARuleResult> CalculatedLLPARuleResults { get; set; } = new List<LLPARuleResult>();

        [Serializable]
        public class LLPARuleResult
        {
            public string Source { get; set; }

            public ObjectId? RuleId { get; set; }

            public string Description { get; set; }

            public string StatusText { get; set; }
        }
    }
}
