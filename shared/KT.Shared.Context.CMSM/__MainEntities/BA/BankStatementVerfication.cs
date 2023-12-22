using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM.BA
{
    [Serializable]
    [BsonDiscriminator(nameof(BankStatementVerfication), Required = true)]
    public sealed class BankStatementVerfication : BaseStep
    {
        public int? AddendumDay { get; set; }
        public string AddendumMonth { get; set; }
        public int? AddendumYear { get; set; }

        public int? OriginallyDay { get; set; }
        public string OriginallyMonth { get; set; }
        public int? OriginallyYear { get; set; }

    }
}
