using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(PortalDocument))]
    public class PortalDocument : KTWrapMongoEntity
    {
        public ObjectId OrganizationId { get; set; }
        
        public ObjectId? BranchId { get; set; }

        public string Name { get; set; }

        public int DocType { get; set; }

        public bool AllowUploadMultiFiles { get; set; }

        public int Index { get; set; }

        public string PortalDocumentCategory { get; set; }

        public int DocumentCategory { get; set; }

        public List<string> DocumentCheckListTypes { get; set; }

    }
}
