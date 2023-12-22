using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(DBA))]
    public class DBA : KTWrapMongoEntity, IIdName
    {
        public ObjectId OrganizationId { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Zip { get; set; }

        public string State { get; set; }

        public bool IsDefault { get; set; }

        public bool IsActive { get; set; }
    }
}
