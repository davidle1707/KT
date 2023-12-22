using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(ScheduledAppointment))]
    public class ScheduledAppointment : KTWrapMongoEntity
    {
        public ObjectId AgentId { get; set; }

        public string Email { get; set; }

        [BsonDateTimeOptions(DateOnly = true, Kind = DateTimeKind.Unspecified)]
        public DateTime Date { get; set; }

        public string Time { get; set; }

        public string Subject { get; set; }
    }

}
