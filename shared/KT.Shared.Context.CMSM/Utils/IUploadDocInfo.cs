using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM.Utils
{
    public interface IUploadDocInfo
    {
        public ObjectId Id { get; set; }

        public string DocName { get; set; }

        public int DocType { get; set; }

        public int DocFileSize { get; set; }

        public string DocFileExtension { get; set; }

        public ObjectId UploadedBy { get; set; }

        public DateTime? UploadedDate { get; set; }
    }
}
