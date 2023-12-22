using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(WysePricerAccount))]
    public class WysePricerAccount : KTWrapMongoEntity
    {
        public ObjectId WhiteLabelId { get; set; }

        public ObjectId OrganizationId { get; set; }

        public string AuthCode { get; set; }

        public DateTime AuthExpiredDate { get; set; }

        public string Emails { get; set; }

        public List<WysePricerAccountSendHistory> SendHistories { get; set; } = new List<WysePricerAccountSendHistory>();

        public List<WysePricerAccountLoginHistory> LoginHistories { get; set; } = new List<WysePricerAccountLoginHistory>();
    }

    [Serializable]
    public class WysePricerAccountSendHistory
    {
        public string Emails { get; set; }

        public string AuthCode { get; set; }

        public DateTime HistoryDate { get; set; }
    }

    [Serializable]
    public class WysePricerAccountLoginHistory
    {
        public string Ip { get; set; }

        public string AuthCode { get; set; }

        public DateTime HistoryDate { get; set; }
    }
}
