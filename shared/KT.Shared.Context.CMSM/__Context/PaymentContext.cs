using MongoDB.Driver;
using MongoDB.Driver.Linq;
using KT.Shared.Context.CMSM.PaymentEntities;
using Entity = KT.Shared.Context.CMSM.PaymentEntities;

namespace KT.Shared.Context.CMSM
{
    public class PaymentContext : __BaseContext
    {
        public PaymentContext(string connectionString, string dbName)
           : base(connectionString, dbName)
        {
        }

        #region User

        public IMongoCollection<PaymentEntities.User> Users => CreateCollection<PaymentEntities.User>();

        public IMongoQueryable<PaymentEntities.User> UsersAsQueryable => Users.AsQueryable();

        #endregion

        #region Account

        public IMongoCollection<Account> Accounts => CreateCollection<Account>();

        public IMongoQueryable<Account> AccountsAsQueryable => Accounts.AsQueryable();

        #endregion

        #region Bank

        public IMongoCollection<Bank> Banks => CreateCollection<Bank>();

        public IMongoQueryable<Bank> BanksAsQueryable => Banks.AsQueryable();

        #endregion

        #region Transaction

        public IMongoCollection<PaymentTransaction> PaymentTransactions => CreateCollection<PaymentTransaction>();

        public IMongoQueryable<PaymentTransaction> PaymentTransactionsAsQueryable => PaymentTransactions.AsQueryable();

        #endregion

        #region GlobalSetting

        public IMongoCollection<GlobalSetting> GlobalSettings => CreateCollection<GlobalSetting>();

        public IMongoQueryable<GlobalSetting> GlobalSettingsAsQueryable => GlobalSettings.AsQueryable();

        #endregion

        #region EmailTemplate

        public IMongoCollection<EmailTemplate> EmailTemplates => CreateCollection<EmailTemplate>();

        public IMongoQueryable<EmailTemplate> EmailTemplatesAsQueryable => EmailTemplates.AsQueryable();

        #endregion

        #region LoginLog

        public IMongoCollection<Entity.LoginLog> LoginLogs => CreateCollection<Entity.LoginLog>();

        public IMongoQueryable<Entity.LoginLog> LoginLogsAsQueryable => LoginLogs.AsQueryable();

        #endregion
    }
}
