using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(Calendar))]
    public class Calendar : KTWrapMongoEntity
    {
        public ObjectId? OwnerId { get; set; }

        public ObjectId? TeamOwnerId { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        public ObjectId OrganizationId { get; set; }

        public ObjectId? BranchId { get; set; }
    }
}
