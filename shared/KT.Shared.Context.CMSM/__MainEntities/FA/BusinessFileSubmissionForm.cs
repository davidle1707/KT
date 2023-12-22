using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public class BusinessFileSubmissionForm
    {
        public bool CompletedTyped { get; set; }

        public bool ItemizedFeeWorksheet { get; set; }

        public bool LPAFindings { get; set; }

        public bool CreditReportDatedWithinSixtyDays { get; set; }

        public bool PreliminaryTitleReport { get; set; }

        public bool SalesContract { get; set; }

        public bool IndividualTaxReturns { get; set; }

        public bool AssetStatements { get; set; }

        public bool StatementAndBusinessLicense { get; set; }

        public bool KOneS { get; set; }

        public bool BusinessFederalTaxReturns { get; set; }

        public bool BusinessNarrativeLetter { get; set; }

        public bool PayStubs { get; set; }

        public bool WTwoS { get; set; }

        public bool SocialSecurity { get; set; }

        public bool FixedIncomeAssetStatements { get; set; }

        public bool CurrentLeaseAgreement { get; set; }

        public bool InvestorWyseRental { get; set; }

        public bool MortgageCoupon { get; set; }

        public bool HOI { get; set; }

        public bool AssetReserves { get; set; }

        public bool LeaseIfApplicable { get; set; }

        public bool SubmissionForm { get; set; }

        public bool FNMAThreeFour { get; set; }

        public bool CreditReportInvoice { get; set; }

    }
}
