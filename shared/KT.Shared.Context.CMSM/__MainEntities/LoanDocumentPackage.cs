using KT.Shared.Context.CMSM.Utils;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(LoanDocumentPackage))]
    public partial class LoanDocumentPackage : KTWrapMongoEntity
    {
        public ObjectId OrganizationId { get; set; }

        public ObjectId? BranchId { get; set; }

        public bool IsActive { get; set; }

        public string Name { get; set; }

        public int Type { get; set; }

        public List<OrgDocument> OrgDocuments { get; set; } = new List<OrgDocument>();

        public List<UploadDocument> UploadDocuments { get; set; } = new List<UploadDocument>();
    }

    public partial class LoanDocumentPackage
    {
        [Serializable]
        public class OrgDocument : KTWrapMongoEntityId
        {
            public bool IsSystem { get; set; }

            public int Order { get; set; }
        }

        [Serializable]
        public class UploadDocument: KTWrapMongoEntityId, IUploadDocInfo
        {
            public bool Enable { get; set; }

            public int Order { get; set; }

            #region IUploadDocInfo

            public string DocName { get; set; }

            public int DocType { get; set; }

            public int DocFileSize { get; set; }

            public string DocFileExtension { get; set; }

            public ObjectId UploadedBy { get; set; }

            public DateTime? UploadedDate { get; set; }

            #endregion
        }
    }
}
