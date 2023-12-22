using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace KT.Shared.Context.CMSM
{
    public partial class MainContext
    {
        #region PortalUser

        public IMongoCollection<PortalUser> PortalUsers => CreateCollection<PortalUser>();

        public IMongoQueryable<PortalUser> PortalUsersAsQueryable => PortalUsers.AsQueryable();

        #endregion

        #region PortalDocument

        public IMongoCollection<PortalDocument> PortalDocuments => CreateCollection<PortalDocument>();

        public IMongoQueryable<PortalDocument> PortalDocumentAsQueryable => PortalDocuments.AsQueryable();

        #endregion

        #region PortalStageStatus

        public IMongoCollection<PortalStageStatus> PortalStageStatus => CreateCollection<PortalStageStatus>();

        public IMongoQueryable<PortalStageStatus> PortalStageStatusAsQueryable => PortalStageStatus.AsQueryable();

        public IAggregateFluent<PortalStageStatus> PortalStageStatusAggregate => PortalStageStatus.Aggregate();

        #endregion

        #region PortalSetting

        public IMongoCollection<PortalSetting> PortalSettings => CreateCollection<PortalSetting>();

        public IMongoQueryable<PortalSetting> PortalSettingsAsQueryable => PortalSettings.AsQueryable();

        public IAggregateFluent<PortalSetting> PortalSettingsAggregate => PortalSettings.Aggregate();

        #endregion

        #region PortalBusinessFile

        public IMongoCollection<PortalBusinessFile> PortalBusinessFiles => CreateCollection<PortalBusinessFile>();

        public IMongoQueryable<PortalBusinessFile> PortalBusinessFilesAsQueryable => PortalBusinessFiles.AsQueryable();

        public IAggregateFluent<PortalBusinessFile> PortalBusinessFilesAggregate => PortalBusinessFiles.Aggregate();

        #endregion
    }
}
