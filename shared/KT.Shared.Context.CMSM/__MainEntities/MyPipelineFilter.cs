using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(MyPipelineFilter))]
    public class MyPipelineFilter : KTWrapMongoEntity
    {
        public ObjectId OrganizationId { get; set; }

        public ObjectId UserId { get; set; }

        public string  Name { get; set; }

        public bool ShowStages { get; set; }

        public int Order { get; set; }

        public BsonDocument Metadata { get; set; }
    }
}
