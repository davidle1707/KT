using System;
using System.Collections.Generic;
using System.Text;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public class BorrowerCreditPublicRecord : KTWrapMongoEntity
    {
        public string AccountOwnershipType { get; set; }

        public string AttorneyName { get; set; }

        public decimal BankruptcyAdjustmentPercent { get; set; }

        public decimal BankruptcyAssetsAmount { get; set; }

        public decimal BankruptcyExemptAmount { get; set; }

        public decimal BankruptcyLiabilitiesAmount { get; set; }

        public decimal BankruptcyRepaymentPercent { get; set; }

        public string BankruptcyType { get; set; }

        public bool ConsumerDisputeIndicator { get; set; }

        public string CourtName { get; set; }

        public string DefendantName { get; set; }

        public bool DerogatoryDataIndicator { get; set; }
                
        public DateTime? DispositionDate { get; set; }

        public string DispositionType { get; set; }

        public string DispositionTypeOtherDescription { get; set; }

        public string DocketIdentifier { get; set; }

        public DateTime? FiledDate { get; set; }

        public decimal LegalObligationAmount { get; set; }

        public bool ManualUpdateIndicator { get; set; }

        public DateTime? PaidDate { get; set; }

        public string PaymentFrequencyType { get; set; }

        public string PlaintiffName { get; set; }

        public DateTime? ReportedDate { get; set; }

        public DateTime? SettledDate { get; set; }

        public string RecordType { get; set; }

        public string TypeOtherDescription { get; set; }
    }
}
