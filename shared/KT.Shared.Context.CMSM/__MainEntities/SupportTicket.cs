using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(SupportTicket))]
    public class SupportTicket : KTWrapMongoEntity
    {
        public ObjectId OrganizationId { get; set; }

        public ObjectId? BranchId { get; set; }

        public ObjectId UserId { get; set; }

        public int? FileNumber { get; set; }

        public string Reference { get; set; }

        public string Subject { get; set; }

        public int Priority { get; set; }

        public int Status { get; set; }

        public DateTime? StatusChangedDate { get; set; }

        public ObjectId? StatusChangedBy { get; set; }

        public int TopicTypeId;

        public DateTime? ReplyLastDate { get; set; }

        public ObjectId? ReplyLastBy { get; set; }

        public List<TicketReply> Replies { get; set; } = new List<TicketReply>();

        public List<TicketAttachFile> AttachFiles { get; set; } = new List<TicketAttachFile>();
    }

    [Serializable]
    public class TicketReply : KTWrapMongoEntity
    {
        public ObjectId UserId { get; set; }
    }

    [Serializable]
    public class TicketAttachFile : KTWrapMongoEntity
    {
        public ObjectId? ReplyId { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public long Length { get; set; }
    }
}
