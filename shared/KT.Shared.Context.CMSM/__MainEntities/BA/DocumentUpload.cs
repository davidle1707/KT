using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM.BA
{
    [Serializable]
    [BsonDiscriminator(nameof(DocumentUpload), Required = true)]
    public sealed class DocumentUpload : BaseStep
    {
        public bool IsSubmitted { get; set; }

        public bool? IsEsignDownloaded { get; set; }

        public List<BrokerApplicationDocument> UploadedDocuments { get; set; } = new List<BrokerApplicationDocument>();
    }

    [Serializable]
    public class BrokerApplicationDocument : KTWrapMongoEntity
    {
        public string DocName { get; set; }

        public int DocType { get; set; }

        public int DocFileSize { get; set; }

        public string DocFileExtension { get; set; }

        public int? DocumentTypeId { get; set; }

    }
}
