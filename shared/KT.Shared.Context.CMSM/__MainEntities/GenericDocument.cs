using KT.Shared.Context.CMSM.Utils;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(GenericDocument))]
    public class GenericDocument : KTWrapMongoEntity, IUploadDocInfo
    {
        public ObjectId OrganizationId { get; set; }

        public ObjectId? BranchId { get; set; }

        public int BusinessType { get; set; }

        public bool IsActive { get; set; }

        public string DocName { get; set; }

        public int DocType { get; set; }

        public int DocFileSize { get; set; }

        public string DocFileExtension { get; set; }

        public ObjectId UploadedBy { get; set; }

        public DateTime? UploadedDate { get; set; }

        public bool IsDefaultToPrint { get; set; }

        public string AllowStates { get; set; }

        public List<ObjectId?> AllowRoles { get; set; } = new List<ObjectId?>();

        public int LoanPurpose { get; set; }
    }
}
