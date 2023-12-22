using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(BusinessFileSubmit))]
    public class BusinessFileSubmit : KTWrapMongoEntity
    {
        public ObjectId FeOrganizationId { get; set; }

        public ObjectId FeBusinessFileId { get; set; }

        public int FeFileNumber { get; set; }

        public ObjectId BeOrganizationId { get; set; }

        public ObjectId BeBusinessFileId { get; set; }

        public int BeFileNumber { get; set; }

        public int Status { get; set; }

        public ObjectId SubmitFileFlowId { get; set; }

        public ObjectId LoanOfficerId { get; set; }

        public List<SubmitFileLog> Logs { get; set; } = new List<SubmitFileLog>();

    }

    [Serializable]
    public class SubmitFileLog : KTWrapMongoEntityId
    {
        public DateTime LoggedDate { get; set; }

        public ObjectId? LoggedBy { get; set; }

        public int Status { get; set; }

        public string Message { get; set; }

    }
}
