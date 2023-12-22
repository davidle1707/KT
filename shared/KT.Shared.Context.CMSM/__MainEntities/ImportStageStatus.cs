using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(ImportStageStatus))]
    public class ImportStageStatus : KTWrapMongoEntity
    {
        public ObjectId OrganizationId { get; set; }

        public int BusinessType { get; set; }

        public ObjectId CustomStageId { get; set; }

        public ObjectId CustomStatusId { get; set; }
                
    }
}
