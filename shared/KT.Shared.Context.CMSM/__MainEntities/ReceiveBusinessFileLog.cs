using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(ReceiveBusinessFileLog))]
    public class ReceiveBusinessFileLog : KTWrapMongoEntity
    {
        public ObjectId? OrganizationId { get; set; }

        public ObjectId? BusinessAppId { get; set; }

        public ObjectId? UserId { get; set; }

        public DateTime ReceivedDate { get; set; }

        public ObjectId? CampaignId { get; set; }

        public string FromSource { get; set; }

        public ObjectId? FromSourceId { get; set; }
    }
}
