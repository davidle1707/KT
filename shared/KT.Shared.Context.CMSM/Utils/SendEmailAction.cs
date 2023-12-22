using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KT.Shared.Context
{
    [Serializable]
    public class SendEmailAction
    {
        [BsonIgnoreIfDefault]
        public bool TrackingOpen { get; set; }

        [BsonIgnoreIfDefault]
        public bool TrackingClick { get; set; }

        [BsonIgnoreIfDefault]
        public bool TrackingUnsubscribe { get; set; }

        [BsonIgnoreIfDefault]
        public bool NotifyOpen { get; set; }

        [BsonIgnoreIfDefault]
        public bool NotifyClick { get; set; }

        [BsonIgnoreIfDefault]
        public bool NotifyUnsubscribe { get; set; }
    }
}
