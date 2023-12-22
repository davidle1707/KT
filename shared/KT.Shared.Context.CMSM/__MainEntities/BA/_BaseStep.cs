using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM.BA
{
    [Serializable]
    [BsonDiscriminator(Required = true)]
    [BsonKnownTypes(
        typeof(InitialApplication),
        typeof(Disclosures),
        typeof(Authorization),
        typeof(WholesaleBrokerAgreeement),
        typeof(CompanyResolution),
        typeof(CreditConsentAuthorization),
        typeof(LoanCompensationAddendum),
        typeof(LoanOfficer),
        typeof(CCPAAddendum),
        typeof(ZeroToleranceFraudPolicy),
        typeof(FBIFraudPolicy),
        typeof(AMLAndSARCompliance),
        typeof(FormW9),
        typeof(BankStatementVerfication),
        typeof(ReviewAndSign),
        typeof(DocumentUpload)
    )]
    public abstract class BaseStep
    {
        public int StepType { get; set; } = 0;
    }
}
