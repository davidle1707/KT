using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM.LogEntities
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(ByteProRestoreLog))]
    public abstract partial class ByteProRestoreLog : KTWrapMongoEntity
    {

    }

    [BsonDiscriminator(Required = true)]
    [BsonKnownTypes(typeof(BpRestoreSettingLog), typeof(BpRestoreLoanLog), typeof(BpRestoreLoanStatisticLog), 
        typeof(BpDocCateMap), typeof(BpDocTypeMap), typeof(BpConditionStageMap))]
    public abstract partial class ByteProRestoreLog
    {
        [Serializable]
        [BsonDiscriminator(nameof(BpRestoreSettingLog), Required = true)]
        public class BpRestoreSettingLog : ByteProRestoreLog
        {
            public string UserName { get; set; }

            public string Password { get; set; }

            public string ApiServerLink { get; set; }

            public string AuthorizationKey { get; set; }

            public string Session { get; set; }

            public bool IsTest { get; set; }

            public int MaxLoansRunSameTime { get; set; }

            public int MaxDocsUploadEachBatch { get; set; }

            #region FileDb

            public string FileDbRootPath { get; set; }

            public string FileDbTempPath { get; set; }

            public bool FileDbIgnoreImpersonate { get; set; }

            public string FileDbImpersonateUserName { get; set; }

            public string FileDbImpersonatePassword { get; set; }

            public string FileDbImpersonateDomain { get; set; }

            #endregion
        }

        [Serializable]
        [BsonDiscriminator(nameof(BpRestoreLoanLog), Required = true)]
        public class BpRestoreLoanLog : ByteProRestoreLog
        {
            public string LqbNumber { get; set; }

            public int? FileDataID { get; set; }

            public int? OrganizationID { get; set; }

            public string OrgCode { get; set; }

            public bool LastRunSuccess { get; set; }

            public bool ForcedRun { get; set; }

            public bool IsRunning { get; set; }

            [BsonIgnoreIfNull]
            public DateTime? LqbLastUpdatedDate { get; set; }

            [BsonIgnoreIfNull]
            public DateTime? LqbLastUpdatedCondition { get; set; }

            public List<BpRestoreDocument> Documents { get; set; }

            public List<BpRestoreCondition> Conditions { get; set; }

        }

        [Serializable]
        [BsonDiscriminator(nameof(BpRestoreLoanStatisticLog), Required = true)]
        public class BpRestoreLoanStatisticLog : ByteProRestoreLog
        {
            public int TotalLoans { get; set; }

            public int TotalRunningLoans { get; set; }

            public int TotalWaitLoans { get; set; }

            public long TotalRunMilliSeconds { get; set; }

            public bool IsCurrent { get; set; }

        }

        [Serializable]
        public class BpRestoreDocument : KTWrapMongoEntityId
        {
            [BsonIgnoreIfNull]
            public bool? IsAuditLog { get; set; }

            public bool LastRunSuccess { get; set; }

            public int DocumentId { get; set; }

            public string Name { get; set; }

            public string Type { get; set; }

            public string Category { get; set; }

            public string Message { get; set; }

            [BsonIgnoreIfNull]
            public DateTime? LqbLastUpdatedDate { get; set; }

        }

        [Serializable]
        public class BpRestoreCondition : KTWrapMongoEntityId
        {
            public int ConditionID { get; set; }

            public int DisplayOrder { get; set; }

            public int ConditionStage { get; set; }

            public int ConditionNo { get; set; }

            [BsonIgnoreIfNull]
            [BsonDictionaryOptions(MongoDB.Bson.Serialization.Options.DictionaryRepresentation.ArrayOfArrays)]
            public Dictionary<string, int> DocumentIds { get; set; }

        }

        [Serializable]
        [BsonDiscriminator(nameof(BpDocCateMap), Required = true)]
        public class BpDocCateMap : ByteProRestoreLog
        {
            public string BpDocCate { get; set; }

            public string LqbFolder { get; set; }

        }

        [Serializable]
        [BsonDiscriminator(nameof(BpDocTypeMap), Required = true)]
        public class BpDocTypeMap : ByteProRestoreLog
        {
            public string BpDocType { get; set; }

            public string LqbDocType { get; set; }

            public string BpDocCate { get; set; }

        }

        [Serializable]
        [BsonDiscriminator(nameof(BpConditionStageMap), Required = true)]
        public class BpConditionStageMap : ByteProRestoreLog
        {
            public string LqbUwCondCate { get; set; }

            public string BpCondStageValue { get; set; }

            public string BpCondStageName { get; set; }

        }
    }
}
