using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace KT.Shared.Context.CMSM.PaymentEntities
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(Bank))]
    public class Bank : KTWrapMongoEntity
    {
        public ObjectId UserId { get; set; }

        public string Name { get; set; }

        public string AccountHolder { get; set; }

        public string RoutingNumber { get; set; }

        public string AccountNumber { get; set; }

        public decimal PaymentAmount { get; set; }

        // more ...
    }
}
