using KT.Shared.Context.CMSM.SendEntities;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace KT.Shared.Context.CMSM
{
    public class SendContext : __BaseContext
    {
        public SendContext(string connectionString, string dbName)
           : base(connectionString, dbName)
        {
        }

        #region Setting

        public IMongoCollection<Setting> Settings => CreateCollection<Setting>();

        public IMongoQueryable<Setting> SettingsAsQueryable => Settings.AsQueryable();

        #endregion

        #region SentLog

        public IMongoCollection<SentLog> SentLogs => CreateCollection<SentLog>();

        public IMongoQueryable<SentLog> SentLogsAsQueryable => SentLogs.AsQueryable();

        #endregion

        #region OtpTransaction

        public IMongoCollection<OtpTransaction> OtpTransactions => CreateCollection<OtpTransaction>();

        public IMongoQueryable<OtpTransaction> OtpTransactionsQueryable => OtpTransactions.AsQueryable();

        #endregion

        #region Client

        public IMongoCollection<Client> Clients => CreateCollection<Client>();

        public IMongoQueryable<Client> ClientsQueryable => Clients.AsQueryable();

        #endregion
    }
}
