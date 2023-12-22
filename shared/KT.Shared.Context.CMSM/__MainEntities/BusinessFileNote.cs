using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(BusinessFileNote))]
    public partial class BusinessFileNote : KTWrapMongoEntity
    {
        public ObjectId BusinessFileId { get; set; }

        public ObjectId? UserId { get; set; }

        public string ActivityNote { get; set; }

        public int NoteType { get; set; }

        public ObjectId? ShareDataId { get; set; }
                
        public string DNQReason { get; set; }

        /// <summary>
        /// add from trigger
        /// </summary>
        public ObjectId? TriggerId { get; set; }
    }

    public partial class BusinessFileNote
    {
        public void ResetNew(ObjectId newFileId, ObjectId? newFileShareDataId, ObjectId? newId = null)
        {
            Id = newId ?? ObjectId.GenerateNewId();
            BusinessFileId = newFileId;
            ShareDataId = newFileShareDataId;
            CreatedBy = null;
            CreatedDate = DateTime.UtcNow;
            ModifiedBy = null;
            ModifiedDate = null;
            TriggerId = null;
        }
    }
}