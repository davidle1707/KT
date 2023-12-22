using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName("Tasks")]
    public class Task1 : KTWrapMongoEntity
    {
        public ObjectId OrganizationId { get; set; }

        public ObjectId? BranchId { get; set; }

        public string Title { get; set; }

        public string Severity { get; set; }

        public string Priority { get; set; }

        public string Category { get; set; }

        public string Status { get; set; }

        public ObjectId? AssignToId { get; set; }

        public ObjectId? AssignToTeamId { get; set; }

        public DateTime? ScheduledDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        public ObjectId? CompletedBy { get; set; }

        public DateTime? ClosedDate { get; set; }

        public ObjectId? ClosedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public ObjectId? UpdatedBy { get; set; }

        public ObjectId? BusinessAppId { get; set; }
    }
}
