using KT.Shared.Context.CMSM.Utils;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public partial class BusinessFileDocument : KTWrapMongoEntity, IUploadDocInfo
    {
		public ObjectId BusinessFileId { get; set; }

        [BsonIgnoreIfNull]
        public ObjectId? PortalDocumentId { get; set; }

        public int LoanPurpose { get; set; }

        public int DocumentCategoryId { get; set; } = 3;

        [BsonIgnoreIfNull]
        public ObjectId? UnderwritingConditionId { get; set; }

        [BsonIgnoreIfNull]
        public DateTime? LOSSubmittedDate { get; set; }

        [BsonIgnoreIfNull]
        public string LOSDocumentId { get; set; }

        [BsonIgnoreIfNull]
        public ObjectId? BankStatementRequestId { get; set; }

        #region IUploadDocInfo

        public string DocName { get; set; }

        public int DocType { get; set; }

        public int DocFileSize { get; set; }

        public string DocFileExtension { get; set; }

        public ObjectId UploadedBy { get; set; }

        [BsonIgnoreIfNull]
        public DateTime? UploadedDate { get; set; }

        #endregion
    }

    public partial class BusinessFileDocument
    {
        public void ResetNew(ObjectId newFileId, ObjectId? newId = null)
        {
            Id = newId ?? ObjectId.GenerateNewId();
            BusinessFileId = newFileId;
            CreatedDate = DateTime.UtcNow;
            CreatedBy = null;
            ModifiedBy = null;
            ModifiedDate = null;
            PortalDocumentId = null;
            UnderwritingConditionId = null;
            LOSSubmittedDate = null;
            LOSDocumentId = null;
            BankStatementRequestId = null;
        }
    }
}