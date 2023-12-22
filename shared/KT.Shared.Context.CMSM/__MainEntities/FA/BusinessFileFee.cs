using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public class BusinessFileFee
    {
        public List<BusinessFileFeeItem> FeeItems { get; set; } = new List<BusinessFileFeeItem>();

        public double TotalAmount { get; set; }

        public string ItemName { get; set; }
    }

    [Serializable]
    public class BusinessFileFeeItem : KTWrapMongoEntityId, IKTWrapCheckListItem
    {
        public int HUDItem { get; set; }

        public string ItemName { get; set; }

        public string FeeName { get; set; }

        public double FeeValue { get; set; }

        public bool IsPercent { get; set; }

        public double Amount { get; set; }

        public bool IsAllowEdit { get; set; }

        public int FeePaidByType { get; set; } = 1;

        public int FeePayableType { get; set; } = 1;

        public string Description { get; set; }

        public bool DisplayDescription { get; set; }

        public double FeeCompressValue { get; set; }

        public double FeeValueAmount { get; set; }
        
        public bool UseFeeAmount { get; set; }

        public bool UseFeePercent { get; set; }

        public bool InvoiceAttached { get; set; }

        public string ListItemId => Id.ToString();

        public string ListItemName => FeeName;
    }

}
