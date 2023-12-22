using System;
using System.Collections.Generic;
using System.Text;

namespace KT.Shared.Context.CMSM.CreditReportEntities
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(DataReportISoftPull))]
    public class DataReportISoftPull : KTWrapMongoEntity
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string Email { get; set; }

        public string ResponseHeading { get; set; }

        public string ResponseContent { get; set; }

        public string ConsumerId { get; set; }

        public string PullType { get; set; }

        public string Result { get; set; }

        public string TimeCreated { get; set; }

        public string TimeUpdated { get; set; }

        public string BranchId { get; set; }

        public string BranchName { get; set; }

        public string LoanOfficerId { get; set; }

        public string LoanOfficerName { get; set; }

        public string LenderId { get; set; }

        public string ReportUrl { get; set; }

        public ScoreData ScoreData { get; set; }

        public string ReportXml { get; set; }

        public int TotalDebt { get; set; }

        public int TotalDebtExcludingRealestate { get; set; }

        public int TotalMonthlyPayments { get; set; }

        public int TotalMonthlyPaymentsExcludingRealestate { get; set; }

        public int RevolvingCreditLimit { get; set; }

        public int RevolvingCreditBalance { get; set; }

        public int DtcRatio { get; set; }

        public object RevolvingCreditLimitExcludingSecured { get; set; }

        public int RevolvingCreditBalanceExcludingSecured { get; set; }

        public int DtcRatioExcludingSecured { get; set; }
    }

    [Serializable]
    public class ScoreData
    {
        public string Score { get; set; }

        public string ScoreModel { get; set; }

        public Factor[] Factors { get; set; }
    }

    [Serializable]
    public class Factor
    {
        public string Code { get; set; }

        public string Statement { get; set; }
    }
}
