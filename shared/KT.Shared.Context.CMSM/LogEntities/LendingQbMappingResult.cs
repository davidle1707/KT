using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM.LogEntities
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(LendingQbMappingResult))]
    public class LendingQbMappingResult : KTWrapMongoEntity
    {
        public ObjectId OrgId { get; set; }

        public ObjectId FileId { get; set; }

        public int FileNumber { get; set; }

        public ObjectId LendingQbId { get; set; }

        public string LendingQbNumber { get; set; }

        public string MapResultJson { get; set; }
    }

}
