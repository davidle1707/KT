using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(CountyLoanLimit))]
    public class CountyLoanLimit : KTWrapMongoEntity, IIdName
    {
        public ObjectId OrganizationId { get; set; }

        public string Name { get; set; }

        public string FIPSCode { get; set; }

        public string State { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal OneUnitLimit { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal TwoUnitLimit { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal ThreeUnitLimit { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal FourUnitLimit { get; set; }
    }
}
