using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM
{
	[Serializable]
    public class BorrowerResidenceInfo : KTWrapMongoEntityId, IKTWrapCheckListItem
    {
        public string Address { get; set; }

        public string City { get; set; }
        
        public string State { get; set; }
        
        public string ZipCode { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? FromDate { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? ToDate { get; set; }

        public string AddressStatus { get; set; }

        public string ListItemId => Id.ToString();

        public string ListItemName => Id.ToString();
    }
}
