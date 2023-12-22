using KT.Shared.Context.CMSM.Utils;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable, KTWrapMongoCollectionName(typeof(BusinessFileLosLoan))]
    [BsonDiscriminator(Required = true)]
    [BsonKnownTypes(typeof(BusinessFileLendingQb), typeof(BusinessFileBytePro))]
    public abstract partial class BusinessFileLosLoan : FileAppShare
    {
        public string LoanNumber { get; set; }

        [LendingQbField("sStatusT", IsLoad = true)]
        public int LoanStatus { get; set; }

        [LendingQbField("sOpenedD", IsLoad = true)]
        public DateTime? LoanOpenDate { get; set; }

        [LendingQbField("sTilGfeOd", IsLoad = true)]
        public DateTime? DisclosureSentDate { get; set; }

        [LendingQbField("sIntentToProceedD", IsLoad = true)]
        public DateTime? DisclosureSignDate { get; set; }

        [LendingQbField("sApprRprtOd", IsLoad = true)]
        public DateTime? AppraisalOrderDate { get; set; }

        [LendingQbField("sApprRprtRd", IsLoad = true)]
        public DateTime? AppraisalReceived { get; set; }

        [LendingQbField("sUnderwritingD", IsLoad = true)]
        public DateTime? SubmitToUWDate { get; set; }

        [LendingQbField("sApprovD", IsLoad = true)]
        public DateTime? UnderwritingApprovedDate { get; set; }

        [LendingQbField("sSuspendedD", IsLoad = true)]
        public DateTime? UnderwritingSuspendedDate { get; set; }

        [LendingQbField("sDocsD", IsLoad = true)]
        public DateTime? DocOutDate { get; set; }

        public DateTime? DocInDate { get; set; }

        [LendingQbField("ClearToCloseDate", IsLoad = true)]
        public DateTime? ClearToCloseDate { get; set; }

        [LendingQbField("sSchedFundD", IsLoad = true)]
        public DateTime? SetFundingDate { get; set; }

        [LendingQbField("sFundD", IsLoad = true)]
        public DateTime? FundedDate { get; set; }

        [LendingQbField("sFundD", IsLoad = true)]
        public DateTime? RateLockedDate { get; set; }

        [LendingQbField("sRLckdD", IsLoad = true)]
        public DateTime? RateLockExpiredDate { get; set; }

        public DateTime? PrelimReportOrderedDate { get; set; }

        public DateTime? PrelimReportReceivedDate { get; set; }

        [LendingQbField("sRejectD", IsLoad = true)]
        public DateTime? LoanDeniedDate { get; set; }

        public DateTime? SubmittedDate { get; set; }

        [LendingQbField("sEstCloseD", IsLoad = true)]
        public DateTime? EstimatedClosingDate { get; set; }

        [LendingQbField("sOnHoldD", IsLoad = true)]
        public DateTime? LoanOnHoldDate { get; set; }

        [LendingQbField("sCanceledD", IsLoad = true)]
        public DateTime? LoanCanceledDate { get; set; }

        public ObjectId LoanOfficerId { get; set; }

        #region huyngo: 02/22/2021

        [LendingQbField("sWithdrawnD", IsLoad = true)]
        public DateTime? WithdrawDate { get; set; }

        [LendingQbField("sQualTopR", IsLoad = true)]
        public decimal? DTITop { get; set; }

        [LendingQbField("sQualBottomR", IsLoad = true)]
        public decimal? DTIBottom { get; set; }

        #endregion

        #region trung: 03/15/2021

        [LendingQbField("sLtvR", IsLoad = true)]
        public decimal? LTV { get; set; }

        #endregion

        #region huyngo: 04/15/2021

        [LendingQbField("sNoteIR", IsLoad = true)] // Submit: sNoteIRMortgage.UsedProductRate
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal? UWNoteRate { get; set; }

        #endregion

        #region huyngo: 05/12/2021

        [LendingQbField("sMersMin", IsLoad = true)]
        public string MERSMINNumber { get; set; } // generic

        [LendingQbField("aTotI", IsLoad = true)]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal? TotalMOnthlyIncome { get; set; } // borrower

        [LendingQbField("aLiaMonTot", IsLoad = true)]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal? TotalMonthlyDebtPayments { get; set; } // borrower

        [LendingQbField("aLiaBalTot", IsLoad = true)]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal? TotalMonthlyOtherDebts { get; set; } // borrower

        [LendingQbField("sProMIns", IsLoad = true)]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal? MonthlyMMIPMIInsurance { get; set; } // loan - property

        [LendingQbField("sProThisMPmt", IsLoad = true)]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal? ProposedMonthlyPayment { get; set; } // loan

        [LendingQbField("sMonthlyPmt", IsLoad = true)]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal? TotalMonthlyPayment { get; set; } // loan

        [LendingQbField("sSchedDueD1", IsLoad = true)]
        public DateTime? FirstPaymentDate { get; set; } // loan

        [LendingQbField("sProdImpound", IsLoad = true)]
        public bool IsProductImpound { get; set; } // loan

        #endregion

        #region huyngo: 05/18/2021

        public bool IsInvalid { get; set; }

        public string InvalidMessage { get; set; }

        #endregion

        #region huyngo: 07/20/2021

        [LendingQbField("sU1LStatD", IsLoad = true)]
        public DateTime? InitialDisclosureDate { get; set; }

        [LendingQbField("sProcessingD", IsLoad = true)]
        public DateTime? InProcessingDate { get; set; }

        [LendingQbField("sApprRprtDueD", IsLoad = true)]
        public DateTime? AppraisalReportDueDate { get; set; }

        [LendingQbField("sLoanSubmittedD", IsLoad = true)]
        public DateTime? LoanSubmittedDate { get; set; }

        [LendingQbField("sConditionReviewD", IsLoad = true)]
        public DateTime? ConditionReviewDate { get; set; }

        [LendingQbField("sConditionReviewN", IsLoad = true)]
        public string ConditionReviewNote { get; set; }

        [LendingQbField("sFinalUnderwritingD", IsLoad = true)]
        public DateTime? FinalUWDate { get; set; }

        [LendingQbField("sFinalUnderwritingDTime", IsLoad = true)]
        public string FinalUWTime { get; set; }

        [LendingQbField("sU2LStatD", IsLoad = true)]
        public DateTime? LockedLEOutDate { get; set; }

        [LendingQbField("sU3LStatD", IsLoad = true)]
        public DateTime? InitialCDDate { get; set; }

        [LendingQbField("sU4LStatD", IsLoad = true)]
        public DateTime? CDRequestDate { get; set; }

        [LendingQbField("sStatusD", IsLoad = true)]
        public DateTime? LoanStatusDate { get; set; }

        #endregion

        #region huyngo: 07/22/2021

        [LendingQbField("sLTotI", IsLoad = true), BsonRepresentation(BsonType.Decimal128)]
        public decimal? VerifiedIncome { get; set; }

        [LendingQbField("sVerifAssetAmt", IsLoad = true), BsonRepresentation(BsonType.Decimal128)]
        public decimal? VerifiedAssets { get; set; }

        [LendingQbField("sProdCashoutAmt", IsLoad = true), BsonRepresentation(BsonType.Decimal128)]
        public decimal? ProdCashOutAmount { get; set; }

        [LendingQbField("sPrepmtPeriodMonths", IsLoad = true)]
        public int? PrepaymentPeriodMonths { get; set; }

        [LendingQbField("sGrossLtvR", IsLoad = true), BsonRepresentation(BsonType.Decimal128)]
        public decimal? GrossLTV { get; set; }

        [LendingQbField("sGrossCltvR", IsLoad = true)]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal? GrossCLTV { get; set; }

        [LendingQbField("sApprRprtExpD", IsLoad = true)]
        public DateTime? AppraisalReportExpiredDate { get; set; }

        [LendingQbField("sAssetExpD", IsLoad = true)]
        public DateTime? AssetExpiredDate { get; set; }

        [LendingQbField("sCrExpD", IsLoad = true)]
        public DateTime? CreditExpiredDate { get; set; }

        [LendingQbField("sIncomeDocExpD", IsLoad = true)]
        public DateTime? IncomeDocExpiredDate { get; set; }

        [LendingQbField("sBondDocExpD", IsLoad = true)]
        public DateTime? InsuranceExpiredDate { get; set; }

        [LendingQbField("sPrelimRprtExpD", IsLoad = true)]
        public DateTime? PrelimReportExpiredDate { get; set; }

        #endregion

        #region huyngo: 07/29/2021

        [LendingQbField("sBrokerLockBaseNoteIR", IsLoad = true), BsonRepresentation(BsonType.Decimal128)]
        public decimal? BrokerLockNoteRate { get; set; }

        [LendingQbField("sBrokerLockBaseBrokComp1PcPrice", IsLoad = true), BsonRepresentation(BsonType.Decimal128)]
        public decimal? BrokerLockPrice { get; set; }

        [LendingQbField("sBrokerLockBaseBrokComp1PcFee", IsLoad = true), BsonRepresentation(BsonType.Decimal128)]
        public decimal? BrokerLockFee { get; set; }

        [LendingQbField("sBrokerLockBaseRAdjMarginR", IsLoad = true), BsonRepresentation(BsonType.Decimal128)]
        public decimal? BrokerLockMargin { get; set; }

        #endregion

        #region huyngo: 08/17/2021

        [LendingQbField("sLPurchaseD", IsLoad = true)] // sPurchasedD -> sLPurchaseD
        public DateTime? PurchasedDate { get; set; }

        [LendingQbField("sInvestorRolodexId", IsLoad = true)]
        public string InvestorRolodexId { get; set; }

        #endregion

        #region huyngo: 09/09/2021

        [LendingQbField("sLpTemplateNm", IsLoad = true)] // Submit: Mortgage.UsedProductName
        public string UsedProgramName { get; set; }

        #endregion

        #region huyngo: 09/23/2021

        [LendingQbField("sU1LockFieldD", IsLoad = true)]
        public DateTime? FloatingLockDate { get; set; }

        #endregion

        #region huyngo: 09/30/2021

        [LendingQbField("sSuspendedN", IsLoad = true)]
        public string UnderwritingSuspendedNote { get; set; }

        #endregion

        #region huyngo: 10/18/2021

        public ObjectId? LastMapLogId { get; set; }

        public DateTime? LastMapLogDate { get; set; }

        #endregion

        #region huyngo: 10/26/2021

        public CheckDataInfo CheckData { get; set; }

        #endregion

        #region huyngo: 11/04/2021

        [LendingQbField("sTotalResidualIncome", IsLoad = true), BsonRepresentation(BsonType.Decimal128)]
        public decimal ResidualIncome { get; set; }

        #endregion

        #region huyngo: 11/19/2021

        [BsonIgnoreIfNull]
        public string[] Tags { get; set; }

        #endregion
    }

    [Serializable, BsonDiscriminator("BytePro", Required = true)]
    public partial class BusinessFileBytePro : BusinessFileLosLoan
    {
        public BusinessFileBytePro()
        {

        }

        public int FileDataID { get; set; }

        public int OrganizationID { get; set; }

        public int LoanID { get; set; }

        public int StatusID { get; set; }

        public int SubPropID { get; set; }

        public int CustomFieldsID { get; set; }

        public List<LosLoanLog> Logs { get; set; } = new List<LosLoanLog>();

        public List<ByteProBorrowerRef> BorrowerRefs { get; set; } = new List<ByteProBorrowerRef>();

        public List<ByteProAssetRef> AssetRefs { get; set; } = new List<ByteProAssetRef>();

        public List<ByteProDebtRef> DebtRefs { get; set; } = new List<ByteProDebtRef>();

        public List<ByteProResidenceRef> ResidenceRefs { get; set; } = new List<ByteProResidenceRef>();

        public List<ByteProEmployerRef> EmployerRefs { get; set; } = new List<ByteProEmployerRef>();

        public List<ByteProIncomeRef> IncomeRefs { get; set; } = new List<ByteProIncomeRef>();

        public List<ByteProDocumentRef> DocumentRefs { get; set; } = new List<ByteProDocumentRef>();

        public List<ByteProConditionRef> ConditionRefs { get; set; } = new List<ByteProConditionRef>();

        public List<ByteProREORef> REORefs { get; set; } = new List<ByteProREORef>();

        public List<ByteProPrepaidItemRef> PrepaidItemRefs { get; set; } = new List<ByteProPrepaidItemRef>();

        public List<ByteProExtFieldRef> ExtFieldRefs { get; set; } = new List<ByteProExtFieldRef>();

        public List<ByteProPriceAdjustmentRef> PriceAdjRefs { get; set; } = new List<ByteProPriceAdjustmentRef>();


    }

    [Serializable, BsonDiscriminator("LendingQb", Required = true)]
    public partial class BusinessFileLendingQb : BusinessFileLosLoan
    {
        public BusinessFileLendingQb(ObjectId id, ObjectId? createdBy = null) : this()
        {
            Id = id;
            CreatedBy = createdBy;
            CreatedDate = DateTime.UtcNow;
        }

        public BusinessFileLendingQb()
        {
        }

        public List<LosLoanLog> Logs { get; set; } = new List<LosLoanLog>();

        public List<LendingQbBorrowerRef> BorrowerRefs { get; set; } = new List<LendingQbBorrowerRef>();

        public List<LendingQbAssetRef> AssetRefs { get; set; } = new List<LendingQbAssetRef>();

        public List<LendingQbLiabilityRef> LiabilityRefs { get; set; } = new List<LendingQbLiabilityRef>();

        public List<LendingQbRealPropertyRef> RealPropertyRefs { get; set; } = new List<LendingQbRealPropertyRef>();

        public List<LendingQbEmpRecordRef> EmpRecordRefs { get; set; } = new List<LendingQbEmpRecordRef>();

        public List<LendingQbIncomeRef> IncomeRefs { get; set; } = new List<LendingQbIncomeRef>();

        public List<LendingQbDocumentRef> DocumentRefs { get; set; } = new List<LendingQbDocumentRef>();

        public List<LendingQbUwConditionRef> UwConditionRefs { get; set; } = new List<LendingQbUwConditionRef>();

        public List<LendingQbHousingHisEntryRef> HousingHisEntryRefs { get; set; } = new List<LendingQbHousingHisEntryRef>();

        #region huyngo: 11/03/2021

        public LosLoanMapping.LendingQBMappingTemplate SubmitTemplate { get; set; }

        #endregion

       
    }

    public partial class BusinessFileLosLoan
    {
        [Serializable]
        public class CheckDataInfo
        {
            public DateTime? SyncDate { get; set; }

            [LendingQbField("sLpTemplateNm", IsLoad = true)]
            public string UsedName { get; set; }

            [LendingQbField("sNoteIR", IsLoad = true), BsonRepresentation(BsonType.Decimal128)]
            public decimal UsedRate { get; set; }

            [LendingQbField("sLDiscntPc", IsLoad = true), BsonRepresentation(BsonType.Decimal128)]
            public decimal UsedPrice { get; set; }

            [LendingQbField("sLPurposeT", IsLoad = true)]
            public int LoanPurpose { get; set; } = -1;

            [LendingQbField("sLAmtCalc", IsLoad = true), BsonRepresentation(BsonType.Decimal128)]
            public decimal LoanAmount { get; set; }

            [LendingQbField("sApprVal", IsLoad = true), BsonRepresentation(BsonType.Decimal128)]
            public decimal EstimatedValue { get; set; }

            [LendingQbField("sPurchPrice", IsLoad = true), BsonRepresentation(BsonType.Decimal128)]
            public decimal PurchasePrice { get; set; }

            [LendingQbField("sGrossLtvR", IsLoad = true), BsonRepresentation(BsonType.Decimal128)]
            public decimal LoanToValue { get; set; }

            [LendingQbField("sGrossCltvR", IsLoad = true), BsonRepresentation(BsonType.Decimal128)]
            public decimal CombinedLoanToValue { get; set; }

            [LendingQbField("aTransmTotI", IsLoad = true), BsonRepresentation(BsonType.Decimal128)]
            public decimal MonthlyIncome { get; set; }

            [LendingQbField("sTotalResidualIncome", IsLoad = true), BsonRepresentation(BsonType.Decimal128)]
            public decimal ResidualIncome { get; set; }

            [LendingQbField("sProThisMPmt", IsLoad = true), BsonRepresentation(BsonType.Decimal128)]
            public decimal PI { get; set; }

            [LendingQbField("sMonthlyPmt", IsLoad = true), BsonRepresentation(BsonType.Decimal128)]
            public decimal PITI { get; set; }

            [LendingQbField("aLiaMonTot", IsLoad = true), BsonRepresentation(BsonType.Decimal128)]
            public decimal MonthlyDebtPayment { get; set; }

            [LendingQbField("sQualTopR", IsLoad = true), BsonRepresentation(BsonType.Decimal128)]
            public decimal FrontEndDTI { get; set; }

            [LendingQbField("sQualBottomR", IsLoad = true), BsonRepresentation(BsonType.Decimal128)]
            public decimal BackEndDTI { get; set; }

            [LendingQbField("sGseSpT", IsLoad = true)]
            public string PropertyType { get; set; }

            [LendingQbField("aOccT", IsLoad = true)]
            public string Occupancy { get; set; }

            [LendingQbField("sUnitsNum", IsLoad = true)]
            public string NumberOfUnits { get; set; }

            [LendingQbField("sSpCounty", IsLoad = true)]
            public string PropertyCounty { get; set; }
        }
    }
}
