using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(IPRestriction))]
    public class IPRestriction : KTWrapMongoEntity
    {
        public ObjectId OrganizationId { get; set; }

        public ObjectId? BranchId { get; set; }

        public ObjectId? UserId { get; set; }

        public string IP { get; set; }

        public bool IsActive { get; set; }

        public bool IsAllow { get; set; }
    }
}