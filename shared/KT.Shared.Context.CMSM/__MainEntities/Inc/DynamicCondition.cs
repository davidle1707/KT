using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM.Inc
{
    [Serializable]
    [BsonDiscriminator(Required = true)]
    [BsonKnownTypes(typeof(DynamicConditionLookupInt), typeof(DynamicConditionRangeDecimal), typeof(DynamicConditionBool))]
    public abstract class DynamicCondition
    {
        public string Field { get; set; }
    }

    [Serializable]
    [BsonDiscriminator("DynamicConditionSingleInt", Required = true)] // existing data is using name "DynamicConditionSingleInt" => will change to typeof(DynamicConditionLookupInt)
    public class DynamicConditionLookupInt : DynamicCondition
    {
        public int? Value { get; set; }
    }

    [Serializable]
    [BsonDiscriminator(nameof(DynamicConditionBool), Required = true)]
    public class DynamicConditionBool : DynamicCondition
    {
        public bool? Value { get; set; }
    }

    [Serializable]
    [BsonDiscriminator(nameof(DynamicConditionRangeDecimal), Required = true)]
    public class DynamicConditionRangeDecimal : DynamicCondition
    {
        [BsonIgnoreIfNull, BsonRepresentation(BsonType.Decimal128)]
        public decimal? ValueFrom { get; set; }

        [BsonIgnoreIfNull, BsonRepresentation(BsonType.Decimal128)]
        public decimal? ValueTo { get; set; }
    }

    
}
