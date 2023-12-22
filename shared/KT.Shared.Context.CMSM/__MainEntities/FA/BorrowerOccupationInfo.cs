using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM
{
	[Serializable]
    public class BorrowerOccupationInfo : KTWrapMongoEntityId, IKTWrapCheckListItem
    {
        public string Address { get; set; }

        public string City { get; set; }
        
        public string State { get; set; }
        
        public string ZipCode { get; set; }

        public string OccupationTitle { get; set; }

        public string CompanyName { get; set; }

        public int NumberOfYears { get; set; }

        public int NumberOfMonths { get; set; }

        public string ListItemId => Id.ToString();

        public string ListItemName => Id.ToString();
    }
}
