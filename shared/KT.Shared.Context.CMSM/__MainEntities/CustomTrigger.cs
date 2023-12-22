using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(CustomTrigger))]
    public class CustomTrigger : KTWrapMongoEntity
    {
        public ObjectId? OrganizationId { get; set; }

        public bool IsActive { get; set; }

        public int BusinessType { get; set; }

        public ObjectId? BranchId { get; set; }

        public string TriggerReference { get; set; }

        public int TriggerType { get; set; }

        public string ActionTrigger { get; set; }

        public int ActionType { get; set; }

        public int? DelayMinutes { get; set; }

        public int? RunMaxRepeat { get; set; }

        public ObjectId TriggerStageId { get; set; }

        public ObjectId TriggerStatusId { get; set; }

        public int? TriggerLoanClassificationType { get; set; }

        [BsonIgnoreIfNull]
        public TriggerLendingQB TriggerLendingQB { get; set; }

        [BsonIgnoreIfNull]
        public TriggerBytePro TriggerBytePro { get; set; }

        public ObjectId? ResultStageId { get; set; }

        public ObjectId? ResultStatusId { get; set; }

        public bool ResultClearAllOwners { get; set; }

        public string ActivityNote { get; set; }

        public ObjectId? ResultQueueId { get; set; }

        public string ColorCode { get; set; }

        [BsonIgnoreIfNull]
        public TriggerValidation Validation { get; set; }

        [BsonIgnoreIfNull]
        public TriggerActionCreateTask CreateTask { get; set; }

        [BsonIgnoreIfNull]
        public TriggerActionSendMail SendMail { get; set; }

        [BsonIgnoreIfNull]
        public TriggerActionSendSMS SendSMS { get; set; }

        [BsonIgnoreIfNull]
        public TriggerActionCGIPost CGIPost { get; set; }

        [BsonIgnoreIfNull]
        public TriggerActionSendMailPortal SendMailPortal { get; set; }

        [BsonIgnoreIfNull]
        public TriggerActionAssignUser AssignUser { get; set; }

        [BsonIgnoreIfNull]
        public TriggerActionPortalSetting PortalSetting { get; set; }

        [BsonIgnoreIfNull]
        public TriggerActionSyncModifyStatus SyncModifyStatus { get; set; }

        [BsonIgnoreIfNull]
        public TriggerActionLockRate LockRate { get; set; }

        [BsonIgnoreIfNull]
        public TriggerActionLendingQbChangeTags LendingQbChangeTags { get; set; }
    }
}
