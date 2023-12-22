using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(ScheduledGuest))]
    public class ScheduledGuest : KTWrapMongoEntity
    {
        public ObjectId AgentId { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }
    }

}
