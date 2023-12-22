using KT.Shared.Context.CMSM.Inc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(LoanProduct))]
    public class LoanProduct : KTWrapMongoEntity
    {
        public ObjectId OrganizationId { get; set; }

        public string ProductReferenceNumber { get; set; }

        public string ProductName { get; set; }

        public string ReferenceSource { get; set; }

        public string Source { get; set; }

        [BsonIgnoreIfNull]
        public string[] QualifyStates { get; set; }

        public string LoanTypes { get; set; }

        public int LoanTerms { get; set; }

        public string LoanProgramTypes { get; set; }

        public List<RuleItem> LoanRules { get; set; } = new List<RuleItem>();

        public List<RuleItem> CreditRules { get; set; } = new List<RuleItem>();

        public string StipulationConditions { get; set; }

        public ObjectId RateSheetId { get; set; }

        public ObjectId RateDetailId { get; set; }

        public ObjectId FeeId { get; set; }

        public bool IsActive { get; set; }

        public string RateType { get; set; }

        public bool IsBalloon { get; set; }

        public decimal MarginPct { get; set; }

        public decimal IndexPct { get; set; }

        public decimal CapPct { get; set; }

        public int RateAdjustmentPeriod { get; set; }

        public string IndexType { get; set; }

        public bool IsInterestOnly { get; set; }

        public string LoanProductType { get; set; }

        public string PrepaymentPenaltyTerm { get; set; }

        public bool IsTest { get; set; }

        public bool IgnoreCheckHighCost { get; set; }

        public bool AllowException { get; set; }

        public List<int> GroupIds { get; set; } = new List<int>();

        public bool UseCountyLoanLimits { get; set; }

        public int? CategoryType { get; set; }

        public int? RateValidationFilterType { get; set; }

        public List<int> FilterGroupIds { get; set; } = new List<int>();

        [BsonIgnoreIfNull]
        public LoanProductRuleTable LoanRuleTable { get; set; } = new LoanProductRuleTable();

        public string GuidelineNote { get; set; }

        [BsonIgnoreIfNull]
        public string[] NoLicenseRequiredStates { get; set; }
    }
}
