using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(CalendarEvent))]
    public class CalendarEvent : KTWrapMongoEntity
    {
        public ObjectId CalendarId { get; set; }

        public string Title { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsDismiss { get; set; }

        public ObjectId? TaskId { get; set; }

        public bool IsReminder { get; set; }

        public int NotifyBy { get; set; }
    }
}
