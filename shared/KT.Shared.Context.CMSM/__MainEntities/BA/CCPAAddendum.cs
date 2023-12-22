using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM.BA
{
    [Serializable]
    [BsonDiscriminator(nameof(CCPAAddendum), Required = true)]
    public sealed class CCPAAddendum : BaseStep
    {
    }
}
