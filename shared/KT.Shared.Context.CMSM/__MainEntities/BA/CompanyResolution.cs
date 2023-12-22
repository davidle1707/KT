using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM.BA
{
    [Serializable]
    [BsonDiscriminator(nameof(CompanyResolution), Required = true)]
    public sealed class CompanyResolution : BaseStep
    {
        public string ResolutionCorporationType { get; set; }
        public DateTime? ResolutionDate { get; set; }
    }
}
