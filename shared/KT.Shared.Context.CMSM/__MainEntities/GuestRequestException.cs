using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(GuestRequestException))]
    public class GuestRequestException : KTWrapMongoEntity
    {
        public ObjectId WhiteLabelId { get; set; }

        public ObjectId OrganizationId { get; set; }

        public string RequestNumber { get; set; }

        public string BorrowerFirstName { get; set; }

        public string BorrowerLastName { get; set; }

        public string AE { get; set; }

        public string Broker { get; set; }

        public int Status { get; set; }

        public int? ExceptionRequestType { get; set; }

        [BsonIgnoreIfNull]
        public ObjectId? ChangeStatusBy { get; set; }

        [BsonIgnoreIfNull]
        public DateTime? ChangeStatusDate { get; set; }

        public List<ExceptionRequestDetail> ExceptionDetails { get; set; } = new List<ExceptionRequestDetail>();

        public List<ExpReqFile> RequestFiles { get; set; } = new List<ExpReqFile>();

        public List<ExpReqNote> Notes { get; set; } = new List<ExpReqNote>();

        [BsonIgnoreIfNull]
        public ExpReqFileAppAssign FileAppAssign { get; set; }
    }

    [Serializable]
    public class ExceptionRequestDetail : KTWrapMongoEntityId
    {
        public DateTime CreatedDate { get; set; }

        public string GuysEmail { get; set; }

        public string PersonSubmittingRequest { get; set; }

        public ExpReqPropertyInfo PropertyInfo { get; set; } = new ExpReqPropertyInfo();

        public ExpReqLoanDetail LoanDetail { get; set; } = new ExpReqLoanDetail();

        public ExpReqOtherInfo OtherInfo { get; set; } = new ExpReqOtherInfo();

        public ExpReqRequestInfo ExceptionRequest { get; set; } = new ExpReqRequestInfo();

        public int Status { get; set; }

        public int StatusCreditTwo { get; set; }

        //public int Status { get; set; }

        [BsonIgnoreIfNull]
        public ObjectId? ChangeStatusBy { get; set; }

        [BsonIgnoreIfNull]
        public DateTime? ChangeStatusDate { get; set; }

        public string Note { get; set; }

    }

    [Serializable]
    public class ExpReqPropertyInfo
    {
        public string Occupancy { get; set; }

        public string ProAddress { get; set; }

        public string PropertyHouseNumber { get; set; }

        public string PropertyCity { get; set; }

        public string PropertyZipCode { get; set; }

        public string PropertyState { get; set; }

        public string PropertyType { get; set; }

        public decimal PropertyValue { get; set; }

        public decimal CurrentInterestRate { get; set; }

    }

    [Serializable]
    public class ExpReqLoanDetail
    {
        public int BorrowerCreditScore { get; set; }

        public int? CoBorrowerCreditScore { get; set; }

        public string LoanClassificationType { get; set; }

        public string LoanType { get; set; }

        public string LoanPurpose { get; set; }

        public string DocType { get; set; }

        public bool IsInterestOnly { get; set; }

        public bool IsEscowImpound { get; set; }

        public decimal RentalIncome { get; set; }

        public decimal DSCR { get; set; }

        public string PrepaymentPenalty { get; set; }

        public decimal LoanAmount { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal PropertyValue { get; set; }

        public decimal DownPayment { get; set; }

        public string LienPosition { get; set; }

        public decimal LoanToValue { get; set; }

        public decimal CombinedLoanToValue { get; set; }

        public decimal FrontEndDTI { get; set; }

        public decimal BackEndDTI { get; set; }

        public bool IsPayingASecond { get; set; }

        public string PurchaseMoneySecondType { get; set; }

        public decimal CashOutAmount { get; set; }

        public string CashOutReason { get; set; }

        public string LoanProductFilterGroupValue { get; set; }
    }

    [Serializable]
    public class ExpReqOtherInfo
    {
        public bool IsSellerContribution { get; set; }

        public bool IsForeignNational { get; set; }

        public bool IsSecondaryFinance { get; set; }

        public string BankruptcyDischargeMonthsAgoType { get; set; }

        public string ForeclosureMonthsAgoType { get; set; }

        public string ShortSaleMonthsAgoType { get; set; }

        public string MortgageHistoryType { get; set; }

        public string ReserveType { get; set; }

    }

    [Serializable]
    public class ExpReqRequestInfo
    {
        public bool IsPricingExceptions { get; set; }

        public string Competitor { get; set; }

        public decimal RequestedRate { get; set; }

        public string DiscountPoint { get; set; }

        public decimal LoanWyseRate { get; set; }

        public string LoanWyseDiscountPoint { get; set; }

        public string Comments { get; set; }

        public string RequestOneCreditType { get; set; }

        public string RequestOneComments { get; set; }

        public decimal RequestOneResidualIncome { get; set; }

        public int RequestOneMonthsOfReserve { get; set; }

        public string RequestTwoCreditType { get; set; }

        public string RequestTwoComments { get; set; }

        public decimal RequestTwoResidualIncome { get; set; }

        public int RequestTwoMonthsOfReserve { get; set; }

        public List<CreditExceptionRequestInfo> CreditExceptionRequests { get; set; }

        public string Category { get; set; }

    }

    [Serializable]
    public partial class ExpReqFile : KTWrapMongoEntityId
    {
        [BsonIgnoreIfNull]
        public ObjectId? DetailId { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public int FileSize { get; set; }

        public DateTime UploadedDate { get; set; }

    }

    [Serializable]
    public class ExpReqNote : KTWrapMongoEntityId
    {
        [BsonIgnoreIfNull]
        public ObjectId? DetailId { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public ObjectId CreatedBy { get; set; }

        public bool IsFromSendEmail { get; set; }

        [BsonIgnoreIfNull]
        public int? CreditExceptionNumber { get; set; }
    }

    [Serializable]
    public class ExpReqFileAppAssign
    {
        public ObjectId FileShareDataId { get; set; }

        public ObjectId FeOrganizationId { get; set; }

        public ObjectId FeBusinessFileId { get; set; }

        public int FeBusinessFileNumber { get; set; }

        public ObjectId BeOrganizationId { get; set; }

        public ObjectId BeBusinessFileId { get; set; }

        public int BeBusinessFileNumber { get; set; }

        public DateTime Date { get; set; }

        public ObjectId By { get; set; }
    }

    [Serializable]
    public class CreditExceptionRequestInfo : KTWrapMongoEntityId
    {
        public string CreditType { get; set; }

        public string Comments { get; set; }

        public decimal ResidualIncome { get; set; }

        public int MonthsOfReserve { get; set; }

        public DateTime RequestDate { get; set; }

        public string Status { get; set; }

        public string Requestor { get; set; }

        public string Category { get; set; }

        public bool LengthOfEmployment { get; set; }

        public bool HighFicoScore { get; set; }

        public bool LargeReserves { get; set; }

        public bool LowDTI { get; set; }

        public bool LowLTV { get; set; }

        public bool StrongCollateral { get; set; }

        public bool MinimalPaymentShock { get; set; }

        public bool LargeResidualIncome { get; set; }

        public DateTime? ApprovalDate { get; set; }

        public DateTime? DeniedDate { get; set; }

        public int CreditExceptionNumber { get; set; }

        public string Note { get; set; }
    }

}
