using MongoDB.Driver;
using MongoDB.Driver.Linq;
using KT.Shared.Context.CMSM.CreditReportEntities;

namespace KT.Shared.Context.CMSM
{
    public class CreditReportContext : __BaseContext
    {
        public CreditReportContext(string connectionString, string dbName)
           : base(connectionString, dbName)
        {
        }

        #region DataReport

        public IMongoCollection<DataReport> DataReports => CreateCollection<DataReport>();

        public IMongoQueryable<DataReport> DataReportsAsQueryable => DataReports.AsQueryable();

        #endregion

        #region HtmlReport

        public IMongoCollection<HtmlReport> HtmlReports => CreateCollection<HtmlReport>();

        public IMongoQueryable<HtmlReport> HtmlReportsAsQueryable => HtmlReports.AsQueryable();

        #endregion


        #region CreditSoftPull

        public IMongoCollection<CreditSoftPull> CreditSoftPulls => CreateCollection<CreditSoftPull>();

        public IMongoQueryable<CreditSoftPull> CreditSoftPullsAsQueryable => CreditSoftPulls.AsQueryable();

        #endregion

        #region ISoftPull

        public IMongoCollection<DataReportISoftPull> DataReportISoftPulls => CreateCollection<DataReportISoftPull>();

        public IMongoQueryable<DataReportISoftPull> DataReportISoftPullsAsQueryable => DataReportISoftPulls.AsQueryable();

        public IMongoCollection<HTMLReportISoftPull> HTMLReportISoftPulls => CreateCollection<HTMLReportISoftPull>();

        public IMongoQueryable<HTMLReportISoftPull> HTMLReportISoftPullsAsQueryable => HTMLReportISoftPulls.AsQueryable();

        #endregion

    }
}
