
using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM
{
	[Serializable]
	public class BusinessFileGeneric
    {
		[ChangeMemberName("Branch")]
		public ObjectId? BranchId { get; set; }

		[ChangeMemberName("Campaign")]
		public ObjectId? CampaignId { get; set; }

		[ChangeMemberName("DBA")]
		public ObjectId? DBAId { get; set; }

		[ChangeMemberName("Color")]
		public string ColorCode { get; set; }

        public string Source { get; set; }

        public string ReferenceNumber { get; set; }

        [ChangeIgnoreCheck]
		public ObjectId? LastOpenedBy { get; set; }

        [ChangeIgnoreCheck]
        public DateTime? LastOpenedDate { get; set; }

        [ChangeIgnoreCheck]
		public DateTime? LastSavedDate { get; set; }

        [ChangeIgnoreCheck]
		public ObjectId? LastSavedBy { get; set; }

        public int? DispositionReasonType { get; set; }

        public string CallStatus { get; set; }

        public bool IsPortalEditable { get; set; }

		#region Delete

		[ChangeIgnoreCheck]
		public ObjectId? DeletedOrganizationId { get; set; }

        [ChangeIgnoreCheck]
		public DateTime? DeletedDate { get; set; }

        [ChangeIgnoreCheck]
		public ObjectId? DeletedBy { get; set; }

        [ChangeIgnoreCheck]
		public DateTime? RestoredDate { get; set; }

        [ChangeIgnoreCheck]
		public ObjectId? RestoredBy { get; set; }

		#endregion
	}
}