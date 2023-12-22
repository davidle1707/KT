using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KT.Shared.Context.CMSM.PaymentEntities
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(PaymentTransaction))]
    public class PaymentTransaction : KTWrapMongoEntity
    {
        public ObjectId UserId { get; set; }

        public ObjectId AccountId { get; set; }

        public ObjectId BankId { get; set; }

        public int PaymentStatus { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal PaymentAmount { get; set; }

        // more ...
    }
}
