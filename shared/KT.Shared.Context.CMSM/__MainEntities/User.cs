using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(User))]
    public class User : KTWrapMongoEntity
    {
        public ObjectId? BranchId { get; set; }

        public int AccessArea { get; set; } = 1; // 1: Client

        public string UserName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string CellPhone { get; set; }

        public int LoginFailed { get; set; }

        public bool IsLocked { get; set; }

        public ObjectId OrganizationId { get; set; }

        public string TimeZoneId { get; set; }

        public ObjectId? EmailServerId { get; set; }

        public string EmailLogin { get; set; }

        public string EmailPassword { get; set; }

        public ObjectId RoleId { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public int? CurrentBusinessType { get; set; }

        public string PhoneExtension { get; set; }

        public string FaxNumber { get; set; }

        public string FaxNotifyEmail { get; set; }

        public bool HasFax { get; set; }

        public UserSetting Settings { get; set; } = new UserSetting();

        public string ThemeName { get; set; }

        public int? AutoSaveAppInterval { get; set; }

        public ObjectId? ReleaseAnnouncementId { get; set; }

        public string SignalRConnectionId { get; set; }

        public DateTime? LockedDate { get; set; }

        public ObjectId? LockedBy { get; set; }

        public string Fax { get; set; }

        public bool CanRunCreditReport { get; set; }

        public bool CanRunCreditSoftPull { get; set; }

        public bool EnableOverrideProgram { get; set; }

        public UserPhoneSetting PhoneSetting { get; set; } = new UserPhoneSetting();

        public ObjectId? OTPTransactionId { get; set; }

        public bool EnableOTP { get; set; }

        public int OTPMethod { get; set; }

        public bool IsLoanOfficer { get; set; }

        public LoanOfficerSetting LoanOfficerSetting { get; set; }

        public UserChangePwdSetting ChangePwdSetting { get; set; } = new UserChangePwdSetting();

        public bool CanAccessWyseGuys { get; set; }

        public bool CanAccessWyseGuysLoanWyse { get; set; }

        public bool CanAccessWyseGuysOptionWide { get; set; }

        /// <summary>
        /// Only apply for NORMAL user
        /// </summary>
        public bool IgnoreShowStagesWhenSaveFile { get; set; }

        public bool IsAccountExecutive { get; set; }

        [BsonIgnoreIfNull]
        public BsonDocument LogTransfered { get; set; }

        public List<ObjectId> AccessPaymentCenterOrgIds { get; set; }
        
        public bool IsAccountManager { get; set; }

        public bool IsUnderwriter { get; set; }

        public bool IsSetupDesk { get; set; }

        public bool IsLoanAssistant { get; set; }

        public bool CanApproveRequestRateLock { get; set; }

        public bool CanAccessInsight { get; set; }

        public bool HasFeatureEmail { get; set; }

        public bool HasFileAppInternalNote { get; set; }

        public string AEImpersonateCode { get; set; }
        
        public bool CanAccessSecureDocs { get; set; }

        [BsonIgnoreIfNull]
        public UserSecondaryConsoleSetting SecondaryConsoleSetting { get; set; }

        [BsonIgnoreIfNull]
        public UserBankStatementAnalyzerSetting BankStatementAnalyzerSetting { get; set; }

        public bool CanApproveChangeOfCircumstance { get; set; }

        public bool CanManageBrokerAppESign { get; set; }

        public bool CanEmailBroadcastBrokers { get; set; }

        public bool CanSetRateUpdatePending { get; set; }

        public bool CanRunCreditISoftPull { get; set; }

        [BsonIgnoreIfNull]
        public bool? CanViewDbQuery { get; set; }

        [BsonIgnoreIfNull]
        public ObjectId? LinkClientContactId { get; set; }
    }
}
