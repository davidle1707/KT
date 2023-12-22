using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM.BA
{
    [Serializable]
    [BsonDiscriminator(nameof(CreditConsentAuthorization), Required = true)]
    public sealed class CreditConsentAuthorization : BaseStep
    {
        public string Officer1Name { get; set; }
        public DateTime? Officer1Date { get; set; }
        public string Officer1SSN { get; set; }
        public string Officer2Name { get; set; }
        public DateTime? Officer2Date { get; set; }
        public string Officer2SSN { get; set; }
        public string Officer3Name { get; set; }
        public DateTime? Officer3Date { get; set; }
        public string Officer3SSN { get; set; }
        public string Officer1Address { get; set; }
        public string Officer1Address2 { get; set; }

        public string Officer2Address { get; set; }
        public string Officer2Address2 { get; set; }
        public string Officer3Address { get; set; }
        public string Officer3Address2 { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? Officer1DOB { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? Officer2DOB { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? Officer3DOB { get; set; }
    }
}
