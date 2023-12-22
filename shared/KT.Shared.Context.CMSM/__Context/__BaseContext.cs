using MongoDB.Driver;
using System.Reflection;

namespace KT.Shared.Context.CMSM
{
#if CMSM_NETCORE
    public abstract class __BaseContext : KT.Db.MongoDB.MongoContext
#else
    public abstract class __BaseContext : ML.Utils.MongoDb.MongoApiContext
#endif
    {
        public __BaseContext(string connectionString, string dbName)
           : base(connectionString, dbName)
        {
        }

#if CMSM_NETCORE
        public IMongoCollection<T> CreateCollection<T>(string name = null, bool cache = true) where T : KT.Common.MongoEntity
            => Collection<T>(name, cache);
#else
        public IMongoCollection<T> CreateCollection<T>(string name = null, bool cache = true) where T : ML.Utils.MongoDb.BaseEntity
            => Collection<T>(name, cache);
#endif
    }
}
