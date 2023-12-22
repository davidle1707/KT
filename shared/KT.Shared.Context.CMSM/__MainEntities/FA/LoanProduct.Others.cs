using KT.Shared.Context.CMSM.Inc;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM.Inc
{
    [Serializable]
    public class LoanProductRuleTable
    {
        public List<LoanProductRuleTableItem> Items { get; set; } = new List<LoanProductRuleTableItem>();
    }

    [Serializable]
    public class LoanProductRuleTableItem : LoanProductTableItem
    {
        public string Name { get; set; }

        public List<DynamicCondition> Conditions { get; set; } = new List<DynamicCondition>();

        public string Message { get; set; }
    }

    [Serializable]
    public abstract class LoanProductTableItem : KTWrapMongoEntityId
    {
        public bool Enable { get; set; }

        public DateTime? ImportedDate { get; set; }

        public string ImportedTransactionId { get; set; }

        public string ImportedNote { get; set; }
    }
}
