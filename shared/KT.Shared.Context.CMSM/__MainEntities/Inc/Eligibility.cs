using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public class EligibilityCredit
    {
        public int CreditRating { get; set; }

        public int CreditScore { get; set; }

        public bool IsBankruptcy { get; set; }

        public int? GradeType { get; set; }

        public int? BankruptcyDischargeMonthsAgoType { get; set; }

        public int? ForeclosureMonthsAgoType { get; set; }

        public int? ShortSaleMonthsAgoType { get; set; }

        public int? ReserveType { get; set; }

        public double TotalNumberOfCreditAccountLates { get; set; }

        public double TotalNumberOfCreditAccount30DaysLates { get; set; }

        public double TotalNumberOfCreditAccount60DaysLates { get; set; }

        public double TotalNumberOfCreditAccount90DaysLates { get; set; }

        public double TotalCollection { get; set; }

        public double TotalLienJudgment { get; set; }

        public int ForeignCreditScore { get; set; }

        public int ITINNumber { get; set; }

    }

    [Serializable]
    public class EligibilityMortgage
    {
        public double LoanAmount { get; set; }

        public double PropertyValue { get; set; }

        public double? LoanToValue { get; set; }

        public double CombinedLoanToValue { get; set; }

        public double? CombinedGrossIncome { get; set; }

        public int Occupancy { get; set; }

        public int LoanPurpose { get; set; }

        public int PropertType { get; set; }

        public int NumberOfUnit { get; set; }

        public double CashoutAmount { get; set; }

        public int LoanTerm { get; set; }

        public int PropertState { get; set; }

        public string PropertyCounty { get; set; }

        public int DocumentType { get; set; }

        public double TotalNetDisposalIncome { get; set; }

        public double TotalDebtToIncomeRatio { get; set; }

        public bool IsInterestOnly { get; set; }

        public bool IsForeignNational { get; set; }

        public int PrepaymentPenalty { get; set; }

        public decimal MortgageBalance1 { get; set; }

        public bool MortgagePaidOff1 { get; set; }

        public string DSCR { get; set; }

        public double ManualDTIValue { get; set; }

        public bool SearchAllLoanTerm { get; set; }

        public int SeasoningType { get; set; }

        public bool IsEscowImpound { get; set; }

        public decimal HousingRatio { get; set; }
    }

    [Serializable]
    public class EligibilityEmployment
    {
        public bool SelfEmployed { get; set; }
    }
}
