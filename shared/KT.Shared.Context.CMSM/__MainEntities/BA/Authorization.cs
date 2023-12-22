using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM.BA
{
    [Serializable]
    [BsonDiscriminator(nameof(Authorization), Required = true)]
    public sealed class Authorization : BaseStep
    {
        public bool? Question1 { get; set; }
        public bool? Question2 { get; set; }
        public bool? Question3 { get; set; }
        public string OfficerName { get; set; }
        public string OfficerTitle { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? OfficerDate { get; set; }
        public bool NotUseTitle { get; set; }
        public string OtherEntityName { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? OtherEntityDate { get; set; }
    }
}
