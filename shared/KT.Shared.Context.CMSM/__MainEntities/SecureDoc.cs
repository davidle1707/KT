using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace KT.Shared.Context.CMSM
{
    /// <summary>
    /// Id = UserId
    /// </summary>
    [KTWrapMongoCollectionName(typeof(SecureDoc)), Serializable]
    public class SecureDoc : SecureFolderItem
    {
        public ObjectId OrganizationId { get; set; }
    }

    [Serializable]
    public class SecureFolderItem : KTWrapMongoEntity
    {
        public string Name { get; set; }

        public List<SecureFolderItem> Folders { get; set; } = new List<SecureFolderItem>();

        public List<SecureFileItem> Files { get; set; } = new List<SecureFileItem>();
    }

    [Serializable]
    public class SecureFileItem : KTWrapMongoEntity
    {
        public string Name { get; set; }

        public string Extension { get; set; }

        public int Size { get; set; }

        public string UploadByEmail { get; set; }
    }

}
