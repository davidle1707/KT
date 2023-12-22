using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(TimedTriggerLog))]
    public class TimedTriggerLog : KTWrapMongoEntity
    {
        public ObjectId BusinessFileId { get; set; }

        public ObjectId CustomTriggerId { get; set; }

        public long ExecutedTimes { get; set; }

        public DateTime LastExecutedDate { get; set; } = DateTime.UtcNow;

        public string LastExecutedAction { get; set; }

        public List<TimedTriggerLogDetail> Details { get; set; } = new List<TimedTriggerLogDetail>();
    }

    [Serializable]
    public class TimedTriggerLogDetail
    {
        public string Action { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
