using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(ItemFeesSetup))]
    public class ItemFeesSetup : KTWrapMongoEntity
    {
        public ObjectId OrganizationId { get; set; }

        public ObjectId FeeId { get; set; }

        public string ItemName { get; set; }

        public bool IsAllowEdit { get; set; }
    }
}
