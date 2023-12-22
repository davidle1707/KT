using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM.LogEntities
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(LendingQbBackUpLog))]
    public abstract partial class LendingQbBackUpLog : KTWrapMongoEntity
    {

    }

    [BsonDiscriminator(Required = true)]
    [BsonKnownTypes(typeof(LqbBackUpSettingLog), typeof(LqbBackUpPhysicalFileLog), typeof(LqbBackUpLoanLog), typeof(LqbBackUpLoanStatisticLog))]
    public abstract partial class LendingQbBackUpLog
    {
        [Serializable]
        [BsonDiscriminator(nameof(LqbBackUpSettingLog), Required = true)]
        public class LqbBackUpSettingLog : LendingQbBackUpLog
        {
            public string UserName { get; set; }

            public string Password { get; set; }

            public string LoanListReportName { get; set; }

            public bool IsTest { get; set; }

            public int MaxLoansRunSameTime { get; set; }

            public int MaxDocsDownloadEachBatch { get; set; }

            public int SecondsWaitEachBatchLoans { get; set; }

            public int SecondsWaitEachBatchDocs { get; set; }

            [BsonIgnoreIfNull]
            //[BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
            public DateTime? FundedDateFrom { get; set; }

            [BsonIgnoreIfNull]
            //[BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
            public DateTime? FundedDateTo { get; set; }

        }

        [Serializable]
        [BsonDiscriminator(nameof(LqbBackUpPhysicalFileLog), Required = true)]
        public class LqbBackUpPhysicalFileLog : LendingQbBackUpLog
        {
            public string Name { get; set; }

            public bool LastRunSuccess { get; set; }

            public int Type { get; set; }

            public bool ForcedRun { get; set; }

            public bool IsRunning { get; set; }

            public bool NeverForcedRun { get; set; }

            [BsonIgnoreIfNull]
            public DateTime? SaveToFileDbDate { get; set; }
        }

        [Serializable]
        [BsonDiscriminator(nameof(LqbBackUpLoanLog), Required = true)]
        public class LqbBackUpLoanLog : LendingQbBackUpLog
        {
            public string LqbNumber { get; set; }

            public string OrgName { get; set; }

            public bool LastRunSuccess { get; set; }

            public bool ForcedRun { get; set; }

            public bool ForcedRunToday { get; set; }

            public bool IsRunning { get; set; }

            [BsonIgnoreIfNull]
            //[BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
            public DateTime? FundedDate { get; set; }

            [BsonIgnoreIfNull]
            public DateTime? LastBackUpUwCondition { get; set; }

            public List<LqbBackUpPhysicalFileLoan> BackUpFiles { get; set; }

            public List<LqbBackUpPhysicalDocument> Documents { get; set; }

            public List<LqbBackUpUwCondition> UwConditions { get; set; }

        }

        [Serializable]
        [BsonDiscriminator(nameof(LqbBackUpLoanStatisticLog), Required = true)]
        public class LqbBackUpLoanStatisticLog : LendingQbBackUpLog
        {
            public int TotalLoans { get; set; }

            public int TotalRunningLoans { get; set; }

            public int TotalWaitLoans { get; set; }

            public int TotalCompletedLoansLastDay { get; set; }

            public long TotalRunMilliSeconds { get; set; }

            public bool IsCurrent { get; set; }

        }

        [Serializable]
        public class LqbBackUpPhysicalFileLoan : KTWrapMongoEntityId
        {
            public int DataType { get; set; }

            [BsonIgnoreIfNull]
            public DateTime? SaveToFileDbDate { get; set; }

            public string Name { get; set; }

            public bool LastRunSuccess { get; set; }

        }

        [Serializable]
        public class LqbBackUpPhysicalDocument : KTWrapMongoEntityId
        {
            [BsonIgnoreIfNull]
            public DateTime? SaveToFileDbDate { get; set; }

            public bool LastRunSuccess { get; set; }

            public string DocId { get; set; }

            public string DocType { get; set; }

            public string FolderName { get; set; }

            public DateTime CreatedDate { get; set; }

            public string Description { get; set; }

        }

        [Serializable]
        public class LqbBackUpUwCondition : KTWrapMongoEntityId
        {
            public int Index { get; set; }

            public string CondId { get; set; }

            public string AssignedTo { get; set; }

            public string Category { get; set; }

            public string CondDesc { get; set; }

            public int CondRowId { get; set; }

            [BsonIgnoreIfNull]
            public DateTime? DueDate { get; set; }

            [BsonIgnoreIfNull]
            public DateTime? FollowUpDate { get; set; }

            [BsonIgnoreIfNull]
            public DateTime? DoneDate { get; set; }

            [BsonIgnoreIfNull]
            public string Notes { get; set; }

            public string Owner { get; set; }

            public string Status { get; set; }

            public List<string> AssociatedDocIds { get; set; }

        }
    }
}
