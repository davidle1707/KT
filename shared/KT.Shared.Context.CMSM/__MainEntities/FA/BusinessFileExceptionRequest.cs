using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM
{
    public class BusinessFileExceptionRequest
    {
        public DateTime Date { get; set; }

        public ObjectId By { get; set; }

        public ObjectId? ExceptionRequestId { get; set; }

    }
}
