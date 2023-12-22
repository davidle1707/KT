using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM.BA
{
    [Serializable]
    [BsonDiscriminator(nameof(WholesaleBrokerAgreeement), Required = true)]
    public sealed class WholesaleBrokerAgreeement : BaseStep
    {
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Phone4 { get; set; }
        public string Phone5 { get; set; }
        public string Phone6 { get; set; }
        public string Phone7 { get; set; }
        public string Phone8 { get; set; }
    }
}
