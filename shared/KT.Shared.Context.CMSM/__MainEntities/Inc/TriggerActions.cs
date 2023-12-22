using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public class TriggerActionAssignUser
    {
        public ObjectId[] UserIds { get; set; }

        public int AssignMode { get; set; }
    }

    [Serializable]
    public class TriggerActionCGIPost
    {
        public string Url { get; set; }

        public int Method { get; set; }

        public List<CGIPostParam> Params { get; set; }
    }

    [Serializable]
    public class TriggerActionCreateTask
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Priority { get; set; }

        public string Status { get; set; }

        public ObjectId? AssignToId { get; set; }

        public DateTime? ScheduledDate { get; set; }
    }

    [Serializable]
    public class TriggerActionPortalSetting
    {
        public bool? CanEdit { get; set; }
    }

    [Serializable]
    public class TriggerActionSendMail
    {
        public string From { get; set; }

        public string ToUsers { get; set; }

        public string ToOwnerByRoles { get; set; }

        public bool ToAppEmail { get; set; }

        public bool ToSyncAppOwner { get; set; }

        public string To { get; set; }

        public string Bcc { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public List<TriggerMailAttachFile> AttachFiles { get; set; } = new List<TriggerMailAttachFile>();

        public string ToFileContactUserTypes { get; set; }

        public bool ToAccountExecutive { get; set; }
    }

    [Serializable]
    public class TriggerMailAttachFile
    {
        public ObjectId Id { get; set; }

        public ObjectId? GenericDocumentId { get; set; }

        public string FileName { get; set; }

        public string FileExt { get; set; }

        public ObjectId UploadedBy { get; set; }

        public DateTime UploadedDate { get; set; }

    }

    [Serializable]
    public class TriggerActionSendMailPortal
    {
        public string From { get; set; }

        public string To { get; set; }

        public string Bcc { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

    }

    [Serializable]
    public class TriggerActionSendSMS
    {
        public ObjectId? FromUserId { get; set; }

        public string ToNumber { get; set; }

        public string Message { get; set; }

        public bool IsToFileOwners { get; set; }

        public bool IsToSyncFileOwners { get; set; }

        public bool IsToBorrower { get; set; }

        public bool IsIncludeCoBorrower { get; set; }

        public bool IsToOtherBorrowers { get; set; }

        public string ToFileContactUserTypes { get; set; }
    }

    [Serializable]
    public class TriggerActionSyncModifyStatus
    {
        public List<ModifyStatus> Items { get; set; }

        [Serializable]
        public class ModifyStatus
        {
            public ObjectId OrganizationId { get; set; }

            public ObjectId StageId { get; set; }

            public ObjectId StatusId { get; set; }

            public ObjectId? FromStageId { get; set; }

            public ObjectId? FromStatusId { get; set; }

            public bool IsClearOwners { get; set; }
        }
    }

    [Serializable]
    public class TriggerActionLockRate
    {
        public bool IsApplyForSync { get; set; }

        public bool IsLocked { get; set; }

        public string Notes { get; set; }
    }

    [Serializable]
    public class TriggerActionLendingQbChangeTags
    {
        public string Command { get; set; }

        public List<string> Tags { get; set; } = new List<string>();
    }
}
