using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace KT.Shared.Context.CMSM
{
    /// <summary>
    /// Id = FolderId
    /// </summary>
    [KTWrapMongoCollectionName(typeof(SecureFolderShare)), Serializable]
    public class SecureFolderShare : KTWrapMongoEntity
    {
        public ObjectId OrganizationId { get; set; }

        public ObjectId SecureDocId { get; set; }

        public ObjectId? FileShareId { get; set; }

        public int? FileNumber { get; set; }
        
        public DateTime? MoveDate { get; set; }

        public List<SecureFolderShareItem> Items { get; set; } = new List<SecureFolderShareItem>();

        public List<SecureFolderShareActionLog> ActionLogs { get; set; } = new List<SecureFolderShareActionLog>();
    }

    [Serializable]
    public class SecureFolderShareItem : KTWrapMongoEntityId
    {
        public ObjectId? BorrowerId { get; set; }

        public string Email { get; set; }

        public string SecureCode { get; set; }

        public int Permission { get; set; }

        public DateTime? SharedDate { get; set; }

        public ObjectId? SharedActionLogId { get; set; }

        public bool IsActive { get; set; }

    }

    [Serializable]
    public class SecureFolderShareActionLog : KTWrapMongoEntityId
    {
        public int LogType { get; set; }

        public string Email { get; set; }

        public string AuthCode { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public ObjectId? CreatedBy { get; set; }
    }
}
