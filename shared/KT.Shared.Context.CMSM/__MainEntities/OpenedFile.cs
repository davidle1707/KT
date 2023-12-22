using System.Collections.Generic;
using System;
using MongoDB.Bson;

namespace KT.Shared.Context.CMSM
{
	[Serializable]
    [KTWrapMongoCollectionName(typeof(OpenedFile))]
    public class OpenedFile : KTWrapMongoEntity
    {
		public ObjectId BusinessFileId { get; set; }

        public ObjectId? PrimaryUserId { get; set; }

        public string ConnectionId { get; set; }

        public List<OtherUser> OtherUsers { get; set; } = new List<OtherUser>();

    }

    [Serializable]
    public class OtherUser : KTWrapMongoEntityId
    {
        public ObjectId UserId { get; set; }

        public string ConnectionId { get; set; }

        public DateTime? OpenedDate { get; set; }
    }
}