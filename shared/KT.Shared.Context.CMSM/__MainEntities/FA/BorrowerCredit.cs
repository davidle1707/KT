using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public class BorrowerCredit
    {
        public string CreditRating { get; set; }

        public int CreditScore { get; set; }

        public bool IsLatePayment { get; set; }

        public int LatePayment { get; set; }

        public bool IsBankruptcy { get; set; }

        public int BankruptcyType { get; set; }

        public bool IsDischarge { get; set; }

        public int DischargeYear { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? DateOfFiling { get; set; }

        public decimal EstimatedBalance { get; set; }

        public decimal Payment { get; set; }

        public string GradeType { get; set; }

        public int? EXPScore { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? EXPRunDate { get; set; }

        public int? TUCScore { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? TUCRunDate { get; set; }

        public int? EQFScore { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? EQFRunDate { get; set; }

        public string BankruptcyDischargeMonthsAgoType { get; set; }

        public string ForeclosureMonthsAgoType { get; set; }

        public string ShortSaleMonthsAgoType { get; set; }

        public string ReserveType { get; set; }

        public bool? IsImportedCreditScore { get; set; }

        public bool IsPreviousForeClosure { get; set; }

        public bool IsPreviousShortSales { get; set; }

        public bool IsPreviousForeBearance { get; set; }

        public DateTime? CreditReportRunDate { get; set; }

        public string CreditorInquiryName { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? CreditorInquiryDate { get; set; }

        public int TotalNumberOfCreditAccount { get; set; }

        public string ReportCompany { get; set; }

        public string ReferenceNumber { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? DateOfCredit { get; set; }

        public string AccessUserName { get; set; }

        public string AccessPassword { get; set; }

        public int ForeignCreditScore { get; set; }

        public int ITINNumber { get; set; }

        #region huyngo: 07/22/2021

        [Description("aBDecisionCreditScore")] // Load, Submit
        public int? DecisionCreditScore { get; set; }

        #endregion
    }
}
