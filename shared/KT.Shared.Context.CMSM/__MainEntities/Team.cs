using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(Team))]
    public class Team : KTWrapMongoEntity, IIdName
    {
        public string Name { get; set; }

        public ObjectId OrganizationId { get; set; }

        public ObjectId? BranchId { get; set; }

        public ObjectId LeaderId { get; set; }

        public List<ObjectId> Users { get; set; } = new List<ObjectId>();
    }
}
