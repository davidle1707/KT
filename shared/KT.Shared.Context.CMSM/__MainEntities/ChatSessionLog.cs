using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(ChatSessionLog))]
    public class ChatSessionLog : KTWrapMongoEntity
    {
        public DateTime StartDate { get; set; }

        public ObjectId FromId { get; set; }

        public ObjectId ToId { get; set; }

        public string ChatLogPath { get; set; }

        public bool IsEnd { get; set; }

        public ObjectId OrganizationId { get; set; }

        public ObjectId? BranchId { get; set; }
    }
}
