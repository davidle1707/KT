using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM
{
	[Serializable]
	public class BorrowerLiability : KTWrapMongoEntity, IKTWrapCheckListItem
    {
        public bool IncludeInCalculations { get; set; } 

	    public string AccountOwnershipType { get; set; }

        public string AccountReportedDate { get; set; }

        public string AccountStatusType { get; set; }

        public string AccountType { get; set; }

        public decimal HighCreditAmount { get; set; }

        public decimal MonthlyPaymentAmount { get; set; }

        public decimal PastDueAmount { get; set; }

        public decimal UnpaidBalanceAmount { get; set; }

        public string CreditBusinessType { get; set; }

        public string CreditLoanType { get; set; }

        public string Creditor { get; set; }

        public string CreditorAddress { get; set; }

        public string CreditorCity { get; set; }

        public string CreditorState { get; set; }

        public string CreditorZipCode { get; set; }

        public string CreditorPhone { get; set; }

        public string CreditorFax { get; set; }

        public string AccountHolderName { get; set; }

        public string AccountNumber { get; set; }

        public string AccountMonthsLeft { get; set; }

        public decimal AccountRate { get; set; }

        public int AccountTerm { get; set; }

        public decimal AccountDue { get; set; }

        public int AccountLate30 { get; set; }

        public int AccountLate60 { get; set; }

        public int AccountLate90Plus { get; set; }

        public bool AccountWillBePaidOff { get; set; }

        public bool AccountPiggyBack { get; set; }

        public bool AccountIncludeInReposession { get; set; }

        public bool AccountIncludeInBankruptcy { get; set; }

        public bool AccountIncludeInForeclosure { get; set; }

        public bool AccountExcludedUnderwriting { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? AccountVerifySentDate { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? AccountReorderDate { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? AccountReceivedDate { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? AccountExpectedDate { get; set; }


        #region Import Credit Report

        public string AccountIdentifier { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? AccountOpenedDate { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? AccountClosedDate { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? AccountPaidDate { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? AccountBalanceDate { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? AccountStatusDate { get; set; }

        public decimal BalloonPaymentAmount { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? BalloonPaymentDueDate { get; set; }

        public decimal ChargeOffAmount { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? ChargeOffDate { get; set; }

        public string CollateralDescription { get; set; }

        public bool ConsumerDisputeIndicator { get; set; }

        public decimal CreditLimitAmount { get; set; }

        public bool DerogatoryDataIndicator { get; set; }

        public decimal HighBalanceAmount { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? LastActivityDate { get; set; }

        public bool ManualUpdateIndicator { get; set; }

        public int MonthsRemainingCount { get; set; }

        public int MonthsReviewedCount { get; set; }

        public string OriginalCreditorName { get; set; }

        public string TermsDescription { get; set; }

        public int TermsMonthsCount { get; set; }

        public string TermsSourceType { get; set; }

        public string CurrentRatingCode { get; set; }
        
        public string CurrentRatingType { get; set; }
        
        public string PaymentPatternDataText { get; set; }
        
        public DateTime? PaymentPatternStartDate { get; set; }

        #endregion

        public bool IsReScheduleLink { get; set; }

        public string ListItemId => Id.ToString();

        public string ListItemName => Id.ToString();
    }
}
