using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(SupportKnowledge))]
    public class SupportKnowledge : KTWrapMongoEntity
    {
        public int TypeId { get; set; }

        public string Title { get; set; }

        public List<SupportKnowledgeAttachFile> AttachFiles { get; set; } = new List<SupportKnowledgeAttachFile>();
    }

    [Serializable]
    public class SupportKnowledgeAttachFile : KTWrapMongoEntity
    {
        public ObjectId? ReplyId { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public long Length { get; set; }
    }
}
