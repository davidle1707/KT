using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(BusinessFileLog))]
    public partial class BusinessFileLog : KTWrapMongoEntity
    {
        public ObjectId BusinessFileId { get; set; }

        public ObjectId ShareDataId { get; set; }

        public DateTime LoggedDate { get; set; }

        public ObjectId? LoggedBy { get; set; }

        public List<ObjectChange> ObjectChanges { get; set; } = new List<ObjectChange>();
    }

    public partial class BusinessFileLog
    {
        [Serializable]
        public class ObjectChange
        {
            public string Name { get; set; }

            public string KindOf { get; set; }

            public string Change { get; set; }

            public string OldValue { get; set; }

            public string NewValue { get; set; }

            [BsonIgnoreIfNull]
            public string ListItemId { get; set; }
        }
    }
   
}
