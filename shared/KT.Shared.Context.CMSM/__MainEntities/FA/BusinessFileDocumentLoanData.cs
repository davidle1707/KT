using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public partial class BusinessFileDocumentLoanData
    {
        #region General

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? EffectiveDate { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? LoanDueDate { get; set; }

        public int? MonthlyPaymentDue { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal? LateCharge { get; set; } // percent

        public string EscrowCompany { get; set; }

        public string EscrowOfficerName { get; set; }

        public string EscrowNumber { get; set; }

        #endregion

        #region Borrower

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal? TotalOtherObligations { get; set; }

        #endregion

        #region Loan

        public string Other1Desc { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal? Other1Amount { get; set; }

        public string Other2Desc { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal? Other2Amount { get; set; }

        /// <summary>
        /// LendingQB.ProposedMonthlyPayment + LendingQB.MonthlyMMIPMIInsurance + Property.MonthlyPropertyTax + Property.MonthlyPropertyInsurance + Other1Amount + Other2Amount
        /// </summary>
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal? TotalMonthlyPayment { get; set; }

        #endregion

        #region Property

        public string FloodInsurance { get; set; }

        public bool IsFloodZone { get; set; }

        public string FloodCommunity { get; set; }

        public string TaxParcelID { get; set; }

        public string APNNumber { get; set; }

        #endregion

        #region Other

        public string InFavorOf { get; set; }

        public string CorporationName { get; set; }

        public string CorporateAuthorizedPersonnel1 { get; set; }

        public string CorporateAuthorizedPersonnel2 { get; set; }

        public string PayToTheOrderOf { get; set; }

        public string WithoutRecourse { get; set; }

        public string TrusteeName { get; set; }

        public string TrusteeAddress { get; set; }

        public string TrusteeCity { get; set; }

        public string TrusteeState { get; set; }

        public string TrusteeZip { get; set; }

        public bool IsAdjustableRateRider { get; set; }

        public bool IsBalloonRider { get; set; }

        public bool Is1to4FamilyRider { get; set; }

        public bool IsCondominiumRider { get; set; }

        public bool IsPlannedUnitDevelopmentRider { get; set; }

        public bool IsBiweeklyPaymentRider { get; set; }

        public bool IsSecondHomeRider { get; set; }

        public bool IsOthersPrepaymentRider { get; set; }

        public string RiderOtherDesc { get; set; }

        public string OrignatorInfo { get; set; }

        public string OrignatorCompanyInfo { get; set; }

        #endregion

        public List<AkaStatementItem> AkaStatementItems { get; set; } = new();
    }

    public partial class BusinessFileDocumentLoanData
    {
        [Serializable]
        public class AkaStatementItem : KTWrapMongoEntityId
        {
            public string VariationName { get; set; }

            public string Description { get; set; }
        }
    }
}
