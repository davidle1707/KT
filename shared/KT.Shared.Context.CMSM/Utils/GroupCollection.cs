using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace KT.Shared.Context
{
#if CMSM_NETCORE
    public class GroupCollection<TEntity> where TEntity : KT.Common.MongoEntity
#else
    public class GroupCollection<TEntity> where TEntity : ML.Utils.MongoDb.BaseEntity
#endif
    {
        private readonly Func<string, bool, IMongoCollection<TEntity>> _getCollection;

        public string PrefixCollection { get; }

        public GroupCollection(Func<string, bool, IMongoCollection<TEntity>> getCollection, string prefixCollection)
        {
            _getCollection = getCollection;
            PrefixCollection = prefixCollection;
        }

        public IMongoCollection<TEntity> this[ObjectId id] => Collection(id.ToString());

        public IMongoCollection<TEntity> this[string id] => Collection(id);

        private IMongoCollection<TEntity> Collection(string userId) => _getCollection($"{PrefixCollection}{userId}", true);
    }
}
