using KT.Db.MongoDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace KT.Db.Context
{
    public abstract class BaseContext : MongoContext
    {
        public BaseContext(string connectionString, string dbName)
         : base(connectionString, dbName)
        {
        }
    }
}
