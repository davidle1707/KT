using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM.BA
{
    [Serializable]
    [BsonDiscriminator(nameof(LoanCompensationAddendum), Required = true)]
    public sealed class LoanCompensationAddendum : BaseStep
    {
        public int CompensationPercent { get; set; }
        public int CompensationAmount { get; set; }
    }
}
