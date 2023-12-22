using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(Organization))]
    public class Organization : KTWrapMongoEntity, IIdName
    {
        public ObjectId? ParentId { get; set; }

        public int Type { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string ContactName { get; set; }

        public string ContactPhone { get; set; }

        public string ContactEmail { get; set; }

        public bool IsActive { get; set; }

        public ObjectId? CreatedByOrgId { get; set; }

        public ObjectId? EmailServerId { get; set; }

        public string EmailLogin { get; set; }

        public string EmailPassword { get; set; }

        public int CurrentAppNumber { get; set; }

        public bool EnableDocuSign { get; set; }

        public string DocuSignEmail { get; set; }

        public string DocuSignPassword { get; set; }

        public string DocuSignAccountId { get; set; }

        public string DocuSignIntegratorKey { get; set; }

        public int DistributeAppType { get; set; }

        public List<int> BusinessTypes { get; set; } = new List<int>();

        public ReportSetting ReportSetting { get; set; } = new ReportSetting();

        public bool IsBackEnd { get; set; }

        public bool EnableChat { get; set; }

        public bool EnableEmail { get; set; }

        public bool EnableSupport { get; set; }

        public bool EnableTaskAlert { get; set; }

        public bool EnableNotification { get; set; }

        public ObjectId? UseWhiteLabelId { get; set; }

        public bool DisableCustomStage { get; set; }

        public bool DisableCustomTrigger { get; set; }

        public bool EnableFax { get; set; }

        public decimal FaxBalance { get; set; }

        public decimal FaxPriceOrderNumber { get; set; }

        public string VitelityFaxUserName { get; set; }

        public string VitelityFaxPassword { get; set; }

        public string PrefixAppNumber { get; set; }

        public int? MaxUsers { get; set; }

        public bool CanManageFrontEndUsers { get; set; }

        public bool EnableAuthenWhiteLabel { get; set; }

        public bool EnableAuthenIpRestriction { get; set; }

        public bool EnableCheckOpenedFile { get; set; }

        public string ContactFax { get; set; }

        public bool EnableAppDataAsCAPS { get; set; }

        public bool EnableSetupProductAndPricing { get; set; }

        public List<OrgLoanProductSetting> LoanProducts { get; set; } = new List<OrgLoanProductSetting>();

        public OrgPhoneSetting PhoneSetting { get; set; } = new OrgPhoneSetting();

        public bool EnableAuthenOTP { get; set; }

        public OTPSetting OTPSetting { get; set; } = new OTPSetting();

        public bool EnableConsumerPortal { get; set; }
        
        public ConsumerPortalSetting ConsumerPortal { get; set; }

        public bool EnableLendingQB { get; set; }

        public LendingQBSetting LendingQB { get; set; }

        public bool EnableBytePro { get; set; }

        public ByteProSetting BytePro { get; set; }

        public List<MenuConfigOrg> MenuConfigs { get; set; } = new List<MenuConfigOrg>();

        public List<ActionMenuConfigOrg> ActionMenuConfigs { get; set; } = new List<ActionMenuConfigOrg>();

        public List<SectionConfigOrg> SectionConfigs { get; set; } = new List<SectionConfigOrg>();

        public string AccountExecutive { get; set; }

        public ObjectId? AccountExecutiveUserId { get; set; }

        public bool EnableTraceLoanProductRules { get; set; }

        public bool EnableTraceLoanRateRules { get; set; }

        public bool EnableTraceLoanFeeRules { get; set; }

        public int? FeeCompensationGroupType { get; set; }

        public int? RateCompensationGroupType { get; set; }

        public CreditReportSetting CreditReportSetting { get; set; } = new CreditReportSetting();

        public ObjectId? KnowledgeBaseUseFromOrgId { get; set; }

        [BsonIgnoreIfNull]
        public ObjectId? LinkBrokerPortalId { get; set; }
        
        public bool IsTest { get; set; }

        public int CheckEligibilityVersion { get; set; }

        public string[] LoanLicenseStates { get; set; }

        public BankStatementOrgSetting BankStatementSetting { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal? PricingProfitMarginAdjustment  { get; set; }

        public List<ExceptionRequestAllowEditFieldConfigOrg> ExceptionRequestAllowEditFieldConfigs { get; set; }

        public PhoneCallRecordingSetting PhoneCallRecordingSetting { get; set; }

        [BsonIgnoreIfNull]
        public OrgLicense License { get; set; }

    }
}