using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM.LogEntities
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(SearchFileAppLog))]
    public class SearchFileAppLog : KTWrapMongoEntity
    {
        public ObjectId OrganizationId { get; set; }

        public ObjectId? BranchId { get; set; }

        public ObjectId ReceiveByUserId { get; set; }

        public ObjectId FileId { get; set; }

        public int FileNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string MarketingQueueNumber { get; set; }

        public bool IsNew { get; set; }

        public List<ObjectId> ExistedOwners { get; set; }

    }
}
