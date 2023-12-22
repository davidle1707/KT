using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public partial class BusinessFileLockProgram
    {
        public bool Locked { get; set; }

        public DateTime? LockedDate { get; set; }

        public int? Status { get; set; }

        public List<RequestLog> Logs { get; set; } = new List<RequestLog>();

        public List<ExtendPrice> ExtendPrices { get; set; }
    }

    public partial class BusinessFileLockProgram
    {
        [Serializable]
        public class ExtendPrice : KTWrapMongoEntity
        {
            public Dictionary<string, string> RequestedInfos { get; set; }

            public decimal? RequestedPrice { get; set; }

            public decimal? ApprovedPrice { get; set; }

            public int? Status { get; set; }

            public List<RequestLog> Logs { get; set; } = new List<RequestLog>();
        }

        [Serializable]
        public class RequestLog
        {
            public int Status { get; set; }

            public DateTime Date { get; set; }

            public ObjectId? By { get; set; }

            public string Note { get; set; }
        }
    }
}
