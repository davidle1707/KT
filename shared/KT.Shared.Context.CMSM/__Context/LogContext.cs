using MongoDB.Driver;
using MongoDB.Driver.Linq;
using KT.Shared.Context.CMSM.LogEntities;
using System.Collections.Concurrent;
using System;

namespace KT.Shared.Context.CMSM
{
    public class LogContext : __BaseContext
    {
        public LogContext(string connectionString, string dbName)
           : base(connectionString, dbName)
        {
        }

        #region QueueJob

        public IMongoCollection<QueueJob> QueueJobs => CreateCollection<QueueJob>();

        public IMongoCollection<QueueJob> QueueJobsWithSuffix(string suffix) => string.IsNullOrWhiteSpace(suffix) ? QueueJobs : CreateCollection<QueueJob>($"QueueJobs_{suffix.ToLower()}");

        #endregion

        #region SendMailLog

        public IMongoCollection<SentMail> SentMails => CreateCollection<SentMail>();

        public IMongoCollection<SentMail> SentMailsWithSuffix(string suffix) => string.IsNullOrWhiteSpace(suffix) ? SentMails : CreateCollection<SentMail>($"SentMails_{suffix.ToLower()}");

        public IMongoCollection<SentMailBody> SentMailBodies => CreateCollection<SentMailBody>();

        public IMongoCollection<SentMailBody> SentMailBodiesWithSuffix(string suffix) => string.IsNullOrWhiteSpace(suffix) ? SentMailBodies : CreateCollection<SentMailBody>($"SentMailBodies_{suffix.ToLower()}");

        #endregion

        #region Deleted

#if CMSM_NETCORE
        public IMongoCollection<T> CollectionDelete<T>() where T : KT.Common.MongoEntity
#else
        public IMongoCollection<T> CollectionDelete<T>() where T : ML.Utils.MongoDb.BaseEntity
#endif
        {
            var name = CollectionName(typeof(T));
            return Collection<T>($"Deleted_{name}", cache: true);
        }

        #endregion

        #region OtpTransaction

        public IMongoCollection<OtpTransaction> OtpTransactions => CreateCollection<OtpTransaction>();

        public IMongoQueryable<OtpTransaction> OtpTransactionsAsQueryable => OtpTransactions.AsQueryable();

        #endregion

        #region LendingQbMappingResult

        public IMongoCollection<LendingQbMappingResult> LendingQbMappingResults => CreateCollection<LendingQbMappingResult>();

        public IMongoQueryable<LendingQbMappingResult> LendingQbMappingResultsAsQueryable => LendingQbMappingResults.AsQueryable();

        #endregion

        #region ImportLead

        public IMongoCollection<ImportLead> ImportLeads => CreateCollection<ImportLead>();

        public IMongoQueryable<ImportLead> ImportLeadsAsQueryable => ImportLeads.AsQueryable();

        #endregion

        #region SearchFileAppLog

        public IMongoCollection<SearchFileAppLog> SearchFileAppLogs => CreateCollection<SearchFileAppLog>();

        public IMongoQueryable<SearchFileAppLog> SearchFileAppLogsAsQueryable => SearchFileAppLogs.AsQueryable();

        #endregion

        #region LendingQbBackUpLog

        public IMongoCollection<LendingQbBackUpLog> LendingQbBackUpLogs => CreateCollection<LendingQbBackUpLog>();

        public IFilteredMongoCollection<LendingQbBackUpLog.LqbBackUpPhysicalFileLog> LqbBackUpPhysicalFiles => LendingQbBackUpLogs.OfType<LendingQbBackUpLog.LqbBackUpPhysicalFileLog>();

        public IFilteredMongoCollection<LendingQbBackUpLog.LqbBackUpLoanLog> LqbBackUpLoans => LendingQbBackUpLogs.OfType<LendingQbBackUpLog.LqbBackUpLoanLog>();

        public IFilteredMongoCollection<LendingQbBackUpLog.LqbBackUpLoanStatisticLog> LqbBackUpLoanStatistics => LendingQbBackUpLogs.OfType<LendingQbBackUpLog.LqbBackUpLoanStatisticLog>();

        #endregion

        #region ByteProRestoreLog

        private GroupCollection<ByteProRestoreLog> _collectionMessage;
        public GroupCollection<ByteProRestoreLog> ByteProRestoreLogs => _collectionMessage ??= new GroupCollection<ByteProRestoreLog>((name, cache) => Collection<ByteProRestoreLog>(name, cache), "ByteProRestoreLogs_");

        #endregion

    }
}
