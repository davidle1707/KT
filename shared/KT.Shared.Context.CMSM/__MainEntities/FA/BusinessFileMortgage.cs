using KT.Shared.Context.CMSM.Utils;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public class BusinessFileMortgage
    {
        [LendingQbField("sLPurposeT", IsSubmit = true, IsLoad = true)]
        public int LoanPurpose { get; set; } = -1;

        [LendingQbField("sLAmtCalc", IsSubmit = true, IsLoad = true)]
        public decimal LoanAmount { get; set; }

        public decimal DownPayment { get; set; }

        public decimal CashoutAmount { get; set; }

        public string CashoutReason { get; set; }

        public string DocType { get; set; }

        public bool HasFoundHome { get; set; }

        public bool FirstTimeHomeBuyer { get; set; }

        public decimal CashReserve { get; set; }

        public int InterestRate { get; set; }

        public bool IsForeignNational { get; set; }

        public bool IsLoanModification { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? LoanModificationDate { get; set; }

        public bool IsNoticeOfDefault { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? NoticeOfDefaultDate { get; set; }

        [BsonIgnoreIfNull]
        public UsedProgramCalculated UsedLoanProduct { get; set; }

        #region 1st Mortgage Info

        public string LenderName1 { get; set; }

        public bool IsEscowImpound1 { get; set; }

        public bool IsPMI1 { get; set; }

        public decimal InterestRate1 { get; set; }

        public string AccountNo1 { get; set; }

        public decimal Balance1 { get; set; }

        public decimal Rate1 { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? LoanDate1 { get; set; }

        public int MonthsDelinq1 { get; set; }

        public decimal Payment1 { get; set; }

        public int Term1 { get; set; }

        public int RateType1 { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? AsOfDate1 { get; set; }

        public bool WillBePaidOff1 { get; set; }

        #endregion

        #region 2nd Mortgage Info

        public string LenderName2 { get; set; }

        public bool IsPurchase2 { get; set; }

        public decimal InterestRate2 { get; set; }

        public string AccountNo2 { get; set; }

        public decimal Balance2 { get; set; }

        public decimal Rate2 { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? LoanDate2 { get; set; }

        public int MonthsDelinq2 { get; set; }

        public decimal Payment2 { get; set; }

        public int Term2 { get; set; }

        public int RateType2 { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? AsOfDate2 { get; set; }

        public bool WillBePaidOff2 { get; set; }

        #endregion

        #region 3th Mortgage Info

        public string AccountNo3 { get; set; }

        public decimal Balance3 { get; set; }

        public decimal Rate3 { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? LoanDate3 { get; set; }

        public int MonthsDelinq3 { get; set; }

        public decimal Payment3 { get; set; }

        public int Term3 { get; set; }

        public int RateType3 { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? AsOfDate3 { get; set; }

        public bool WillBePaidOff3 { get; set; }

        #endregion

        public string LienPosition { get; set; }

        public string InitialSTIPSChecklist { get; set; }

        public bool IsEscowImpoundNew { get; set; }

        public int LoanClassificationType { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? EscrowCloseDate { get; set; }

        public string DSCR { get; set; }

        public string DocumentCheckList { get; set; }

        public string LoanType { get; set; }

        public string AmortizationType { get; set; }

        public string RateLockStatus { get; set; }

        public bool SecondaryFinance { get; set; }

        public bool SellerContribution { get; set; }

        public string DueTerm { get; set; }

        public decimal QualifyRate { get; set; }

        #region new 12/12/2019 

        public decimal EstimatePrepaidItems { get; set; }

        public decimal PmiMipFundingFee { get; set; }

        public decimal DiscountFeeBorrowerPay { get; set; }

        public decimal SubbordinateFinancing { get; set; }

        public decimal ClosingCostPayBySeller { get; set; }

        public decimal OtherCredit { get; set; }

        public string OtherCreditExplanation { get; set; }

        public decimal LoanAmtExcludeMipFee { get; set; }

        #endregion

        #region huyngo: 01/27/2021

        public int SeasoningType { get; set; }

        #endregion

        #region huyngo: 04/27/2021

        public int? PrepaymentPenalty { get; set; }

        #endregion

        #region huyngo: 07/22/2021

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal? UWDSCRValue { get; set; } // this real value of DSCR

        #endregion
                
        public string BankStatementSource { get; set; }
                
        public bool FirstTimeInvestor { get; set; }
    }
}