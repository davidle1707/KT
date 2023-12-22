using MongoDB.Bson;
using System;


namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(DocuSignLog))]
    public class DocuSignLog : KTWrapMongoEntity
    {
		public ObjectId? BusinessFileId { get; set; }

        public DateTime? LastCheckedDate { get; set; }

        public string DocuSignEnvelopeId { get; set; }

        public string DocuSignEnvelopeStatus { get; set; }

        public DateTime? DocuSignEnvelopeDate { get; set; }

        public int DocusignEnvelopeRecipients { get; set; }

        public DateTime LoggedDate { get; set; }

        public ObjectId? LoggedBy { get; set; }

        public string Status { get; set; }

        public string Subject { get; set; }

        public string EmailBlur { get; set; }

        public string SignerByJson { get; set; }

        public string LoggedNotes { get; set; }

		public ObjectId? ShareDataId { get; set; }

        public DateTime? SentDate { get; set; }

        public DateTime? DeliveredDate { get; set; }

        public DateTime? SignedDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        public DateTime? DeclinedDate { get; set; }

        public string VoidedReason { get; set; }

        public ObjectId OrganizationId { get; set; }

        public ObjectId? BranchId { get; set; }
    }
}
