using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM.BA
{
    [Serializable]
    [BsonDiscriminator(nameof(ZeroToleranceFraudPolicy), Required = true)]
    public sealed class ZeroToleranceFraudPolicy : BaseStep
    {
    }
}
