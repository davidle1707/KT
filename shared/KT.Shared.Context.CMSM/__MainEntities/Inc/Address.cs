using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public class Address
    {
        [BsonIgnoreIfNull]
        public string Street { get; set; }

        [BsonIgnoreIfNull]
        public string City { get; set; }

        [BsonIgnoreIfNull]
        public string Zip { get; set; }

        [BsonIgnoreIfNull]
        public string State { get; set; }
    }
}
