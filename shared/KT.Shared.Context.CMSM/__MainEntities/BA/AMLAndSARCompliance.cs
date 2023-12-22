using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM.BA
{
    [Serializable]
    [BsonDiscriminator(nameof(AMLAndSARCompliance), Required = true)]
    public sealed class AMLAndSARCompliance : BaseStep
    {
    }
}
