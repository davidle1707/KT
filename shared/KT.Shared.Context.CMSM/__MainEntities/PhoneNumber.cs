using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(PhoneNumber))]
    public class PhoneNumber : KTWrapMongoEntity
    {
        public int VendorType { get; set; }

        public string Number { get; set; }

        public ObjectId? OrganizationId { get; set; }

        public ObjectId? UserId { get; set; }
    }
}
