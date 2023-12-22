using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(SalesNexusContact))]
    public partial class SalesNexusContact : KTWrapMongoEntity
    {
        public string ExternalId { get; set; }

        public string Company { get; set; }

        public ObjectId? LinkBrokerId { get; set; }

        public ObjectId? LinkInternalId { get; set; }

        public Dictionary<string, FieldValue> Fields { get; set; } = new Dictionary<string, FieldValue>();

        public string Source { get; set; }
    }

    public partial class SalesNexusContact
    {
        [Serializable]
        public class FieldValue
        {
            public string Value { get; set; }

            [BsonIgnoreIfDefault]
            public string Note { get; set; }
        }
    }
}
