
using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM
{
	[Serializable]
	public class BusinessFileUser :  KTWrapMongoEntityId
	{
		public ObjectId UserId { get; set; }

		public int AccessMode { get; set; }

		public DateTime AddedDate { get; set; }

		public ObjectId? AddedBy { get; set; }

		public DateTime? RemovedDate { get; set; }

		public ObjectId? RemovedBy { get; set; }
	}
}
