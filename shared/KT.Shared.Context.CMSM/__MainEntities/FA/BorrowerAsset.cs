using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM
{
	[Serializable]
	public class BorrowerAsset : KTWrapMongoEntityId, IKTWrapCheckListItem
    {
        public bool IncludeInCalculations { get; set; } 

	    public string OwnerType { get; set; }

        public string AssetType { get; set; }

        public string AccountNumber { get; set; }

        public decimal AssetValue { get; set; }

        public string Description { get; set; }

        public bool IsGiftFunds { get; set; }

        public string GiftFundsSource { get; set; }

        public string CompanyName { get; set; }

        public string DepartmentName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string AccountHolderName { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? VerifySentDate { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? ReorderDate { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? ReceivedDate { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? ExpectedDate { get; set; }

        public string ListItemId => Id.ToString();

        public string ListItemName => Id.ToString();
    }
}
