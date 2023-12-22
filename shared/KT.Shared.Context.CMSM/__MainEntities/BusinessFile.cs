using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(BusinessFile))]
    public class BusinessFile : KTWrapMongoEntity
    {
        public ObjectId OrganizationId { get; set; }

        public ObjectId ShareDataId { get; set; }

        public int BusinessType { get; set; }
        
        public int FileNumber { get; set; }

        public int AppType { get; set; }

        public BusinessFileGeneric Generic { get; set; } = new BusinessFileGeneric();

        public List<BusinessFileStage> Stages { get; set; } = new List<BusinessFileStage>();

        public List<BusinessFileUser> Users { get; set; } = new List<BusinessFileUser>();
    }
}