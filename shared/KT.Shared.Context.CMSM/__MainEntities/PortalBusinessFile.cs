using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(PortalBusinessFile))]
    public class PortalBusinessFile : KTWrapMongoEntity
    {
        public ObjectId ShareDataId { get; set; }

        public ObjectId OrganizationId { get; set; }

        public bool IsSync { get; set; }

        public BusinessFileBorrower PrimaryBorrower { get; set; } = new BusinessFileBorrower();

        public List<BusinessFileBorrower> CoBorrowers { get; set; } = new List<BusinessFileBorrower>();

        public BusinessFileMortgage Mortgage { get; set; }

        public BusinessFileProperty Property { get; set; }

        public List<PortalBusinessFileComment> Comments { get; set; } = new List<PortalBusinessFileComment>();

    }

    [Serializable]
    public class PortalBusinessFileComment : KTWrapMongoEntity
    {

    }
}
