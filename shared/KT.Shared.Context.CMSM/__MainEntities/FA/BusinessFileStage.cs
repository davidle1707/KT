using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public class BusinessFileStage : KTWrapMongoEntityId
    {
        public DateTime AddedDate { get; set; }

        public ObjectId? AddedBy { get; set; }

        public DateTime? RemovedDate { get; set; }

        public ObjectId? RemovedBy { get; set; }

        public ObjectId StageId { get; set; }

        public ObjectId StatusId { get; set; }

        public string Reason { get; set; }
    }
}
