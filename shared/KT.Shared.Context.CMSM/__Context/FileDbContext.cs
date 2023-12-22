using KT.Shared.Context.CMSM.FileDbEntities;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace KT.Shared.Context.CMSM
{
    public class FileDbContext : __BaseContext
    {
        public FileDbContext(string connectionString, string dbName)
          : base(connectionString, dbName)
        {
        }

        #region FileExpire

        public IMongoCollection<FileExpire> FileExpires => CreateCollection<FileExpire>();

        public IMongoQueryable<FileExpire> DataReportsAsQueryable => FileExpires.AsQueryable();

        #endregion

        #region FileExpireInfo

        public IMongoCollection<FileExpireInfo> FileExpireInfos => CreateCollection<FileExpireInfo>();

        public IMongoQueryable<FileExpireInfo> FileExpireInfosAsQueryable => FileExpireInfos.AsQueryable();

        #endregion
    }
}
