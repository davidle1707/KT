using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(CreditReportLog))]
    public class CreditReportLog : KTWrapMongoEntity
    {
        public ObjectId OrganizationId { get; set; }

        public ObjectId? BranchId { get; set; }

        public ObjectId BusinessFileId { get; set; }

        public ObjectId ShareDataId { get; set; }

        public int FileNumber { get; set; }

        public ObjectId BorrowerId { get; set; }

        public ObjectId? AdditionalBorrowerId { get; set; }

        public bool HasTransUnion { get; set; }

        public bool HasExperian { get; set; }

        public bool HasEquifax { get; set; }

        public string ApiVendorOrderId { get; set; }

        public string ResponseStatus { get; set; }

        public List<CreditReportAccessLog> AccessedLogs { get; set; } = new List<CreditReportAccessLog>();

        public List<CreditReportImportDataLog> ImportDataLogs { get; set; } = new List<CreditReportImportDataLog>();

        public int Provider { get; set; }

        #region ISoftPull

        public int ForceRepull { get; set; }

        public decimal? AnnualIncome { get; set; }

        public int HardPull { get; set; }

        public int? MLA { get; set; }

        public int? LenderId { get; set; }

        public int? ApplicantId { get; set; }

        #endregion
    }

    [Serializable]
    public class CreditReportAccessLog
    {
        public DateTime AccessedDate { get; set; }

        public ObjectId AccessedBy { get; set; }

        public string ResponseStatus { get; set; }
    }

    [Serializable]
    public class CreditReportImportDataLog
    {
        public DateTime ImportedDate { get; set; }

        public ObjectId ImportedBy { get; set; }

        public int ImportedType { get; set; }
    }
}
