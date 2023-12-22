using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(ScheduleTrigger))]
    [BsonDiscriminator(Required = true)]
    public abstract partial class ScheduleTrigger : KTWrapMongoEntity
    {
        public string TriggerType { get; set; }

        public int ActionType { get; set; }

        public bool Enable { get; set; }

        public DateTime? StartAt { get; set; }

        public DateTime? EndAt { get; set; }

        [BsonIgnoreIfNull]
        public string Metadata { get; set; }

        public string ResponseError { get; set; }

        [BsonIgnoreIfNull]
        public string IgnoreTimes { get; set; }

        [BsonIgnoreIfNull]
        public string IgnoreDays { get; set; }

        [BsonIgnoreIfNull]
        public string IgnoreTimeZoneId { get; set; }

        public List<ObjectId> ExecutedQueueJobIds { get; set; } = new List<ObjectId>();
    }

    #region Cron
    
    [BsonKnownTypes(typeof(ExportReport))]
    [BsonKnownTypes(typeof(SyncLendingQb))]
    [BsonKnownTypes(typeof(BackUpLendingQbLoan))]
    [BsonKnownTypes(typeof(ContactStrategy))]
    public partial class ScheduleTrigger
    {
        [Serializable]
        public abstract class CronTrigger : ScheduleTrigger
        {
            public string Period { get; set; }

            public string Expression { get; set; }

            public string ExpressionDesc { get; set; }

            protected CronTrigger()
            {
                TriggerType = "cron";
            }
        }

        [Serializable]
        [BsonDiscriminator(nameof(ExportReport), Required = true)]
        public class ExportReport : CronTrigger
        {
            public int Type { get; set; }

            public string NotifyEmails { get; set; }
        }

        [Serializable]
        [BsonDiscriminator(nameof(SyncLendingQb), Required = true)]
        public class SyncLendingQb : CronTrigger
        {
            public string NotifyEmails { get; set; }

            public string NotifyWhen { get; set; }

            public ObjectId[] OrgIds { get; set; }

            public ObjectId[] NotOrgIds { get; set; }

            public ObjectId[] FileIds { get; set; }

            public ObjectId[] NotFileIds { get; set; }

            public string[] LqbNumbers { get; set; }

            public string[] NotLqbNumbers { get; set; }

            public bool? IsInvalid { get; set; }

            public bool? IsFunded { get; set; }

            public bool? IsPurchased { get; set; }
        }

        [Serializable]
        [BsonDiscriminator(nameof(BackUpLendingQbLoan), Required = true)]
        public class BackUpLendingQbLoan : CronTrigger
        {
            public string NotifyEmails { get; set; }

            public string NotifyWhen { get; set; }

            public int MaxLoansPerDay { get; set; }

            public string WorkingTimeZoneId { get; set; }
        }

        [Serializable]
        [BsonDiscriminator(nameof(ContactStrategy), Required = true)]
        public class ContactStrategy : CronTrigger
        {
            public ObjectId UserId { get; set; }

            public ObjectId OrgId { get; set; }

            public BsonDocument Request { get; set; }
        }
    }

    #endregion

    #region Simple

    [BsonKnownTypes(typeof(ContactBorrowers))]
    public partial class ScheduleTrigger
    {
        [Serializable]
        public abstract class SimpleTrigger : ScheduleTrigger
        {
            public bool IsNoRepeat { get; set; }

            public int RepeatIntervalSeconds { get; set; }

            /// <summary>
            /// -1 => forever
            /// </summary>
            public int RepeatCount { get; set; }

            protected SimpleTrigger()
            {
                TriggerType = "simple";
            }
        }

        [Serializable]
        [BsonDiscriminator(nameof(ContactBorrowers), Required = true)]
        public class ContactBorrowers : SimpleTrigger
        {
            public ObjectId UserId { get; set; }

            public ObjectId OrgId { get; set; }

            public List<ObjectId> FileIds { get; set; } = new List<ObjectId>();

            public ObjectId TemplateId { get; set; }
        }
    }

    #endregion
}
