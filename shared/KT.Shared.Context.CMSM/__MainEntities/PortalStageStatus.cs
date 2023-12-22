using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(PortalStageStatus))]
    public class PortalStageStatus : KTWrapMongoEntity, IIdName
    {
        public ObjectId OrganizationId { get; set; }

        public int BusinessType { get; set; }

        public ObjectId CustomStageId { get; set; }

        public ObjectId? CustomStatusId { get; set; }

        public string Name { get; set; }

        public int Index { get; set; }

        public string Icon { get; set; }
    }
}
