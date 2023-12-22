using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(CustomStage))]
    public class CustomStage : KTWrapMongoEntity, IIdName
    {
        public ObjectId OrganizationId { get; set; }

        public int BusinessType { get; set; }

        public string Name { get; set; }

        public int Index { get; set; }

        public bool ForAppBroker { get; set; }
    }
}
