using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(Branch))]
    public class Branch : KTWrapMongoEntity, IIdName
    {
        public ObjectId OrganizationId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string ContactName { get; set; }

        public string ContactPhone { get; set; }

        public string ContactMail { get; set; }

        public bool IsActive { get; set; }

        public string AccountExecutive { get; set; }

        public ObjectId? AccountExecutiveUserId { get; set; }
    }
}
