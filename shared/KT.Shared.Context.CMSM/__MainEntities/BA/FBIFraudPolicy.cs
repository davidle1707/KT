using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM.BA
{
    [Serializable]
    [BsonDiscriminator(nameof(FBIFraudPolicy), Required = true)]
    public sealed class FBIFraudPolicy : BaseStep
    {
    }
}
