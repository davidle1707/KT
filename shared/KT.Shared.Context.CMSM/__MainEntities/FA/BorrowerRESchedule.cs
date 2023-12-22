using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace KT.Shared.Context.CMSM
{
	[Serializable]
	public class BorrowerRESchedule  : KTWrapMongoEntity, IKTWrapCheckListItem
    {
	    public string Address { get; set; }

	    public string City { get; set; }

        public string ZipCode { get; set; }

        public string State { get; set; }

        public string PropertyType { get; set; }

        public DateTime? DateAcquired { get; set; }

        public decimal OriginalCost { get; set; }

        public decimal MortgagePayment { get; set; }

        public decimal MortgageAmount { get; set; }

        public decimal MarketValue { get; set; }

        public decimal GrossRent { get; set; }

        public string OwnerType { get; set; }

        public decimal OccRate { get; set; }

        public string Status { get; set; }

        public bool IsSubjectProperty { get; set; }

        public decimal TotalInsTaxOther { get; set; }

        public string REOType { get; set; }

        public string CurrentUsageType { get; set; }

        public string IntendedUsageType { get; set; }

        public List<ObjectId> LinkLiabilityIds { get; set; }

        public string ListItemId => Id.ToString();

        public string ListItemName => Id.ToString();
    }
}