using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM.CreditReportEntities
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(CreditSoftPull))]
    public class CreditSoftPull : KTWrapMongoEntity
    {
        public ObjectId OrganizationId { get; set; }

        public ObjectId? BranchId { get; set; }

        public ObjectId BorrowerId { get; set; }

        public ObjectId BusinessFileId { get; set; }

        public int FileNumber { get; set; }

        public ObjectId ShareDataId { get; set; }

        public DateTime? LastImportedDate { get; set; }

        public CreditSoftPullData CreditSoftPullData { get; set; } = new CreditSoftPullData();

        public List<CreditReportImportDataLog> ImportDataLogs { get; set; } = new List<CreditReportImportDataLog>();
    }

    [Serializable]
    public class CreditSoftPullData
    {

        public int ScoreUsed { get; set; }

        public int NoOfStudentLoans { get; set; }

        public decimal TotalStudentLoansBalance { get; set; }

        public int StudentLoanDelinquent { get; set; }

        public decimal TotalMonthlyStudentLoanPayment { get; set; }

        public int TotalCreditCardAccounts { get; set; }

        public decimal TotalCreditCardBalance { get; set; }

        public int NumberCreditCardDelinquent { get; set; }

        public decimal TotalMonthlyCreditCardPayment { get; set; }


        public int TotalAutoLoanAccounts { get; set; }


        public decimal TotalAutoLoanBalance { get; set; }


        public int NumberAutoLoanDelinquent { get; set; }


        public decimal TotalMonthlyAutoLoanPayment { get; set; }


        public int TotalMortgageLoanAccounts { get; set; }


        public decimal TotalMortgageLoanBalance { get; set; }


        public int NumberMortgageLoanDelinquent { get; set; }


        public decimal TotalMonthlyMortgageLoanPayment { get; set; }


        public string MortgageLenderName { get; set; }


        public int TotalOtherLoanAccounts { get; set; }


        public decimal TotalOtherLoanBalance { get; set; }


        public int NumberOtherLoanDelinquent { get; set; }


        public decimal TotalMonthlyOtherLoanPayment { get; set; }
    }

}
