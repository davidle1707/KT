using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(TransferFileLog))]
    public class TransferFileLog : KTWrapMongoEntity
    {
        public ObjectId BusinessFileId { get; set; }

        public ObjectId ToUserId { get; set; }

        public ObjectId ByUserId { get; set; }

        public DateTime TransferredDate { get; set; }

        public ObjectId TransferredBy { get; set; }

        public string Notes { get; set; }

        public ObjectId? StageId { get; set; }

        public ObjectId? StatusId { get; set; }
    }
}
