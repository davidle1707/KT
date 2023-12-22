using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(SalesNexusLink))]
    public partial class SalesNexusLink : KTWrapMongoEntity
    {
        public ObjectId BrokerId { get; set; }

        public List<LinkContact> Contacts { get; set; } = new List<LinkContact>();
    }

    public partial class SalesNexusLink
    {
        [Serializable]
        public class LinkContact : KTWrapMongoEntity
        {
            public int Type { get; set; }

            public string ExternalId { get; set; }

            public ObjectId InternalId { get; set; }
        }
    }
}
