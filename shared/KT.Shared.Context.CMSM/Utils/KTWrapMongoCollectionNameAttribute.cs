using System;
#if CMSM_NETCORE
using KT.Db.MongoDB;
#else
using ML.Utils.MongoDb;
#endif

namespace KT.Shared.Context
{
    public class KTWrapMongoCollectionNameAttribute : CollectionNameAttribute
    {
        public KTWrapMongoCollectionNameAttribute(string name) : base(name)
        {
        }

        public KTWrapMongoCollectionNameAttribute(Type type) : base(type)
        {
        }
    }
}
