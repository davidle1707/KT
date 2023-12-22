using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace KT.Shared.Context.CMSM
{
    public partial class MainContext : __BaseContext
    {
        public MainContext(string connectionString, string dbName)
           : base(connectionString, dbName)
        {
        }

        #region BusinessFile

        public IMongoCollection<BusinessFile> BusinessFiles => CreateCollection<BusinessFile>();

        public IMongoQueryable<BusinessFile> BusinessFilesAsQueryable => BusinessFiles.AsQueryable();

        public IAggregateFluent<BusinessFile> BusinessFilesAggregate => BusinessFiles.Aggregate();

        #endregion

        #region BusinessFileShareData

        public IMongoCollection<BusinessFileShareData> BusinessFileShareData => CreateCollection<BusinessFileShareData>();

        public IMongoQueryable<BusinessFileShareData> BusinessFileShareDataAsQueryable => BusinessFileShareData.AsQueryable();

        public IAggregateFluent<BusinessFileShareData> BusinessFileShareDataAggregate => BusinessFileShareData.Aggregate();

        #endregion

        #region AppSetting

        public IMongoCollection<AppSetting> AppSettings => CreateCollection<AppSetting>();

        public IMongoQueryable<AppSetting> AppSettingsAsQueryable => AppSettings.AsQueryable();

        #endregion

        #region Branch

        public IMongoCollection<Branch> Branches => CreateCollection<Branch>();

        public IMongoQueryable<Branch> BranchesAsQueryable => Branches.AsQueryable();

        #endregion

        #region BusinessFileNote

        public IMongoCollection<BusinessFileNote> BusinessFileNotes => CreateCollection<BusinessFileNote>();

        public IMongoQueryable<BusinessFileNote> BusinessFileNotesAsQueryable => BusinessFileNotes.AsQueryable();

        #endregion

        #region BusinessFileLog

        public IMongoCollection<BusinessFileLog> BusinessFileLogs => CreateCollection<BusinessFileLog>();

        public IMongoQueryable<BusinessFileLog> BusinessFileLogsAsQueryable => BusinessFileLogs.AsQueryable();

        #endregion

        #region BusinessType

        public IMongoCollection<BusinessType> BusinessTypes => CreateCollection<BusinessType>();

        public IMongoQueryable<BusinessType> BusinessTypesAsQueryable => BusinessTypes.AsQueryable();

        #endregion

        #region Calendar

        public IMongoCollection<Calendar> Calendars => CreateCollection<Calendar>();

        public IMongoQueryable<Calendar> CalendarsAsQueryable => Calendars.AsQueryable();

        #endregion

        #region CalendarEvent

        public IMongoCollection<CalendarEvent> CalendarEvents => CreateCollection<CalendarEvent>();

        public IMongoQueryable<CalendarEvent> CalendarEventsAsQueryable => CalendarEvents.AsQueryable();

        #endregion

        #region Campaign

        public IMongoCollection<Campaign> Campaigns => CreateCollection<Campaign>();

        public IMongoQueryable<Campaign> CampaignsAsQueryable => Campaigns.AsQueryable();

        #endregion

        #region CGIPostSetting

        public IMongoCollection<CGIPostSetting> CGIPostSettings => CreateCollection<CGIPostSetting>();

        public IMongoQueryable<CGIPostSetting> CGIPostSettingsAsQueryable => CGIPostSettings.AsQueryable();

        #endregion

        #region CGIPostLog

        public IMongoCollection<CGIPostLog> CGIPostLogs => CreateCollection<CGIPostLog>();

        public IMongoQueryable<CGIPostLog> CGIPostLogsAsQueryable => CGIPostLogs.AsQueryable();

        #endregion

        #region ChatSessionLog

        public IMongoCollection<ChatSessionLog> ChatSessionLogs => CreateCollection<ChatSessionLog>();

        public IMongoQueryable<ChatSessionLog> ChatSessionLogsAsQueryable => ChatSessionLogs.AsQueryable();

        #endregion

        #region CustomStage

        public IMongoCollection<CustomStage> CustomStages => CreateCollection<CustomStage>();

        public IMongoQueryable<CustomStage> CustomStagesAsQueryable => CustomStages.AsQueryable();

        #endregion

        #region CustomStageStatus

        public IMongoCollection<CustomStageStatus> CustomStageStatus => CreateCollection<CustomStageStatus>();

        public IMongoQueryable<CustomStageStatus> CustomStageStatusAsQueryable => CustomStageStatus.AsQueryable();

        #endregion

        #region DBA

        public IMongoCollection<DBA> DBAs => CreateCollection<DBA>();

        public IMongoQueryable<DBA> DBAsAsQueryable => DBAs.AsQueryable();

        #endregion

        #region EmailServer

        public IMongoCollection<EmailServer> EmailServers => CreateCollection<EmailServer>();

        public IMongoQueryable<EmailServer> EmailServersAsQueryable => EmailServers.AsQueryable();

        #endregion

        #region CustomField: Fixed, Dynamic

        public IMongoCollection<CustomField> CustomFields => CreateCollection<CustomField>();

        public IFilteredMongoCollection<CustomField.Fixed> FixedFields => CustomFields.OfType<CustomField.Fixed>();

        public IFilteredMongoCollection<CustomField.Dynamic> DynamicFields => CustomFields.OfType<CustomField.Dynamic>();

        #endregion

        #region GenericDocument

        public IMongoCollection<GenericDocument> GenericDocuments => CreateCollection<GenericDocument>();

        public IMongoQueryable<GenericDocument> GenericDocumentsAsQueryable => GenericDocuments.AsQueryable();

        #endregion

        #region IPRestriction

        public IMongoCollection<IPRestriction> IPRestrictions => CreateCollection<IPRestriction>();

        public IMongoQueryable<IPRestriction> IPRestrictionsAsQueryable => IPRestrictions.AsQueryable();

        #endregion

        #region ImportStageStatus

        public IMongoCollection<ImportStageStatus> ImportStageStatus => CreateCollection<ImportStageStatus>();

        public IMongoQueryable<ImportStageStatus> ImportStageStatusAsQueryable => ImportStageStatus.AsQueryable();

        #endregion

        #region LetterTemplate

        public IMongoCollection<LetterTemplate> LetterTemplates => CreateCollection<LetterTemplate>();

        public IMongoQueryable<LetterTemplate> LetterTemplatesAsQueryable => LetterTemplates.AsQueryable();

        #endregion

        #region RawLead

        public IMongoCollection<RawLead> RawLeads => CreateCollection<RawLead>();

        public IMongoQueryable<RawLead> RawLeadsAsQueryable => RawLeads.AsQueryable();

        #endregion

        #region ReceiveBusinessFileLog

        public IMongoCollection<ReceiveBusinessFileLog> ReceiveBusinessFileLogs => CreateCollection<ReceiveBusinessFileLog>();

        public IMongoQueryable<ReceiveBusinessFileLog> ReceiveBusinessFileLogsAsQueryable => ReceiveBusinessFileLogs.AsQueryable();

        #endregion

        #region ReleaseAnnouncement

        public IMongoCollection<ReleaseAnnouncement> ReleaseAnnouncements => CreateCollection<ReleaseAnnouncement>();

        public IMongoQueryable<ReleaseAnnouncement> ReleaseAnnouncementsAsQueryable => ReleaseAnnouncements.AsQueryable();

        #endregion

        #region SupportKnowledge

        public IMongoCollection<SupportKnowledge> SupportKnowledges => CreateCollection<SupportKnowledge>();

        public IMongoQueryable<SupportKnowledge> SupportKnowledgesAsQueryable => SupportKnowledges.AsQueryable();

        #endregion

        #region Support

        public IMongoCollection<SupportTicket> SupportTickets => CreateCollection<SupportTicket>();

        public IMongoQueryable<SupportTicket> SupportTicketsQueryable => SupportTickets.AsQueryable();

        public IAggregateFluent<SupportTicket> SupportTicketsAggregate => SupportTickets.Aggregate();

        #endregion

        #region Team

        public IMongoCollection<Team> Teams => CreateCollection<Team>();

        public IMongoQueryable<Team> TeamsAsQueryable => Teams.AsQueryable();

        #endregion

        #region Task

        public IMongoCollection<Task1> Tasks => CreateCollection<Task1>();

        public IMongoQueryable<Task1> TasksAsQueryable => Tasks.AsQueryable();

        #endregion

        #region TimedTriggerLog

        public IMongoCollection<TimedTriggerLog> TimedTriggerLogs => CreateCollection<TimedTriggerLog>();

        public IMongoQueryable<TimedTriggerLog> TimedTriggerLogsAsQueryable => TimedTriggerLogs.AsQueryable();

        #endregion

        #region TransferFileLog

        public IMongoCollection<TransferFileLog> TransferFileLogs => CreateCollection<TransferFileLog>();

        public IMongoQueryable<TransferFileLog> TransferFileLogsAsQueryable => TransferFileLogs.AsQueryable();

        #endregion

        #region GlobalSetting

        public IMongoCollection<GlobalSetting> GlobalSettings => CreateCollection<GlobalSetting>();

        public IMongoQueryable<GlobalSetting> GlobalSettingsAsQueryable => GlobalSettings.AsQueryable();

        #endregion

        #region WhiteLabel

        public IMongoCollection<WhiteLabel> WhiteLabels => CreateCollection<WhiteLabel>();

        public IMongoQueryable<WhiteLabel> WhiteLabelsAsQueryable => WhiteLabels.AsQueryable();

        #endregion

        #region WysePricerAccount

        public IMongoCollection<WysePricerAccount> WysePricerAccounts => CreateCollection<WysePricerAccount>();

        public IMongoQueryable<WysePricerAccount> WysePricerAccountsAsQueryable => WysePricerAccounts.AsQueryable();

        #endregion

        #region User

        public IMongoCollection<User> Users => CreateCollection<User>();

        public IMongoQueryable<User> UsersAsQueryable => Users.AsQueryable();

        public IMongoCollection<User> UsersWithLock(bool locked) => locked ? CreateCollection<User>("UsersLocked") : Users;

        #endregion

        #region PhoneNumber

        public IMongoCollection<PhoneNumber> PhoneNumbers => CreateCollection<PhoneNumber>();

        #endregion

        #region ItemFeesSetup

        public IMongoCollection<ItemFeesSetup> ItemFeesSetups => CreateCollection<ItemFeesSetup>();

        public IMongoQueryable<ItemFeesSetup> ItemFeesSetupsAsQueryable => ItemFeesSetups.AsQueryable();

        #endregion

        #region MasterFeesSetup

        public IMongoCollection<MasterFeesSetup> MasterFeesSetups => CreateCollection<MasterFeesSetup>();

        public IMongoQueryable<MasterFeesSetup> MasterFeesSetupsAsQueryable => MasterFeesSetups.AsQueryable();

        #endregion

        #region SubmitBusinessFileFlow

        public IMongoCollection<SubmitBusinessFileFlow> SubmitBusinessFileFlows => CreateCollection<SubmitBusinessFileFlow>();

        public IMongoQueryable<SubmitBusinessFileFlow> SubmitBusinessFileFlowsAsQueryable => SubmitBusinessFileFlows.AsQueryable();

        #endregion

        #region PhoneLog

        public IMongoCollection<PhoneLog> PhoneLogs => CreateCollection<PhoneLog>();

        #endregion
        
        #region CreditReportLog

        public IMongoCollection<CreditReportLog> CreditReportLogs => CreateCollection<CreditReportLog>();

        public IMongoQueryable<CreditReportLog> CreditReportLogsAsQueryable => CreditReportLogs.AsQueryable();

        #endregion

        #region Stipulation

        public IMongoCollection<Stipulation> Stipulations => CreateCollection<Stipulation>();

        public IMongoQueryable<Stipulation> StipulationsAsQueryable => Stipulations.AsQueryable();

        #endregion

        #region Fee

        public IMongoCollection<Fee> Fees => CreateCollection<Fee>();

        public IMongoQueryable<Fee> FeesAsQueryable => Fees.AsQueryable();

        #endregion

        #region RateSheet

        public IMongoCollection<RateSheet> RateSheets => CreateCollection<RateSheet>();

        public IMongoQueryable<RateSheet> RateSheetsAsQueryable => RateSheets.AsQueryable();

        #endregion

        #region LoanProduct

        public IMongoCollection<LoanProduct> LoanProducts => CreateCollection<LoanProduct>();

        public IMongoQueryable<LoanProduct> LoanProductsAsQueryable => LoanProducts.AsQueryable();

        #endregion

        #region DashboardCampaignSetting

        public IMongoCollection<DashboardCampaignSetting> DashboardCampaignSettings => CreateCollection<DashboardCampaignSetting>();

        public IMongoQueryable<DashboardCampaignSetting> DashboardCampaignSettingsAsQueryable => DashboardCampaignSettings.AsQueryable();

        #endregion

        #region BusinessFileSubmit

        public IMongoCollection<BusinessFileSubmit> BusinessFileSubmits => CreateCollection<BusinessFileSubmit>();

        public IMongoQueryable<BusinessFileSubmit> BusinessFileSubmitsAsQueryable => BusinessFileSubmits.AsQueryable();

        #endregion

        #region BusinessFileProgram

        public IMongoCollection<BusinessFileProgram> BusinessFilePrograms => CreateCollection<BusinessFileProgram>();

        public IMongoQueryable<BusinessFileProgram> BusinessFileProgramsAsQueryable => BusinessFilePrograms.AsQueryable();

        #endregion

        #region ESignLogs

        public IMongoCollection<ESignLog> ESignLogs => CreateCollection<ESignLog>();

        public IMongoQueryable<ESignLog> ESignLogsAsQueryable => ESignLogs.AsQueryable();

        public IAggregateFluent<ESignLog> ESignLogsAggregate => ESignLogs.Aggregate();

        #endregion

        #region ESignSettings

        public IMongoCollection<ESignSetting> ESignSettings => CreateCollection<ESignSetting>();

        public IMongoQueryable<ESignSetting> ESignSettingsAsQueryable => ESignSettings.AsQueryable();

        public IAggregateFluent<ESignSetting> ESignSettingsAggregate => ESignSettings.Aggregate();

        public IFilteredMongoCollection<ESignSetting.GlobalESignSetting> GlobalESignSettings => ESignSettings.OfType<ESignSetting.GlobalESignSetting>();

        public IMongoQueryable<ESignSetting.GlobalESignSetting> GlobalESignSettingsAsQueryable => GlobalESignSettings.AsQueryable();

        public IFilteredMongoCollection<ESignSetting.OrganizationESignSetting> OrgESignSettings => ESignSettings.OfType<ESignSetting.OrganizationESignSetting>();

        public IMongoQueryable<ESignSetting.OrganizationESignSetting> OrgESignSettingsAsQueryable => OrgESignSettings.AsQueryable();

        public IFilteredMongoCollection<ESignSetting.RequestTypeESignSetting> ReqTypeESignSettings => ESignSettings.OfType<ESignSetting.RequestTypeESignSetting>();

        public IMongoQueryable<ESignSetting.RequestTypeESignSetting> ReqTypeESignSettingsAsQueryable => ReqTypeESignSettings.AsQueryable();

        public IFilteredMongoCollection<ESignSetting.DocumentESignSetting> DocESignSettings => ESignSettings.OfType<ESignSetting.DocumentESignSetting>();

        public IMongoQueryable<ESignSetting.DocumentESignSetting> DocESignSettingsAsQueryable => DocESignSettings.AsQueryable();

        public IFilteredMongoCollection<ESignSetting.WebhookESignSetting> WebhookESignSettings => ESignSettings.OfType<ESignSetting.WebhookESignSetting>();

        public IMongoQueryable<ESignSetting.WebhookESignSetting> WebhookESignSettingsAsQueryable => WebhookESignSettings.AsQueryable();

        #endregion

        #region OpenedFile

        public IMongoCollection<OpenedFile> OpenedFiles => CreateCollection<OpenedFile>();

        public IMongoQueryable<OpenedFile> OpenedFilesAsQueryable => OpenedFiles.AsQueryable();

        #endregion

        #region CustomTrigger

        public IMongoCollection<CustomTrigger> CustomTriggers => CreateCollection<CustomTrigger>();

        public IMongoQueryable<CustomTrigger> CustomTriggersAsQueryable => CustomTriggers.AsQueryable();

        #endregion

        #region Role

        public IMongoCollection<Role> Roles => CreateCollection<Role>();

        public IMongoQueryable<Role> RolesAsQueryable => Roles.AsQueryable();

        #endregion

        #region Organization

        public IMongoCollection<Organization> Organizations => CreateCollection<Organization>();

        public IMongoQueryable<Organization> OrganizationsAsQueryable => Organizations.AsQueryable();

        public IMongoCollection<OrganizationLosSubmit> OrganizationLosSubmits => CreateCollection<OrganizationLosSubmit>();

        public IMongoQueryable<OrganizationLosSubmit> OrganizationLosSubmitsAsQueryable => OrganizationLosSubmits.AsQueryable();

        #endregion

        #region LosLoanMapping

        //public IMongoCollection<LendingQBMapping> LendingQBMappings => CreateCollection<LendingQBMapping>();
        public IMongoCollection<LosLoanMapping> LosLoanMappings => CreateCollection<LosLoanMapping>();

        // LendingQB

        public IFilteredMongoCollection<LosLoanMapping.LendingQBMappingLoan> LendingQBMappingLoans => LosLoanMappings.OfType<LosLoanMapping.LendingQBMappingLoan>();

        public IMongoQueryable<LosLoanMapping.LendingQBMappingLoan> LendingQBMappingLoansAsQueryable => LendingQBMappingLoans.AsQueryable();

        public IFilteredMongoCollection<LosLoanMapping.LendingQBMappingDocType> LendingQBMappingDocTypes => LosLoanMappings.OfType<LosLoanMapping.LendingQBMappingDocType>();

        public IMongoQueryable<LosLoanMapping.LendingQBMappingDocType> LendingQBMappingDocTypesAsQueryable => LendingQBMappingDocTypes.AsQueryable();

        public IFilteredMongoCollection<LosLoanMapping.LendingQBMappingTemplate> LendingQBMappingTemplates => LosLoanMappings.OfType<LosLoanMapping.LendingQBMappingTemplate>();

        public IMongoQueryable<LosLoanMapping.LendingQBMappingTemplate> LendingQBMappingTemplatesAsQueryable => LendingQBMappingTemplates.AsQueryable();

        // BytePro

        public IFilteredMongoCollection<LosLoanMapping.ByteProMappingLoan> ByteProMappingLoans => LosLoanMappings.OfType<LosLoanMapping.ByteProMappingLoan>();

        public IFilteredMongoCollection<LosLoanMapping.ByteProMappingDocType> ByteProMappingDocTypes => LosLoanMappings.OfType<LosLoanMapping.ByteProMappingDocType>();

        public IFilteredMongoCollection<LosLoanMapping.ByteProExtendField> ByteProExtendFields => LosLoanMappings.OfType<LosLoanMapping.ByteProExtendField>();

        #endregion

        #region LoginLog

        public IMongoCollection<LoginLog> LoginLogs => CreateCollection<LoginLog>();

        public IMongoQueryable<LoginLog> LoginLogsAsQueryable => LoginLogs.AsQueryable();

        #endregion

        #region BusinessFileLosLoan: BusinessFileLendingQb, BusinessFileBytePro

        public IMongoCollection<BusinessFileLosLoan> BusinessFileLosLoans => CreateCollection<BusinessFileLosLoan>();

        #endregion

        #region BrokerApplication

        public IMongoCollection<BrokerApplication> BrokerApplications => CreateCollection<BrokerApplication>();

        public IMongoQueryable<BrokerApplication> BrokerApplicationsAsQueryable => BrokerApplications.AsQueryable();

        #endregion

        #region DocuSignLog

        public IMongoCollection<DocuSignLog> DocuSignLogs => CreateCollection<DocuSignLog>();

        public IMongoQueryable<DocuSignLog> DocuSignLogsAsQueryable => DocuSignLogs.AsQueryable();

        #endregion

        #region CountyLoanLimit

        public IMongoCollection<CountyLoanLimit> CountyLoanLimits => CreateCollection<CountyLoanLimit>();

        public IMongoQueryable<CountyLoanLimit> CountyLoanLimitsAsQueryable => CountyLoanLimits.AsQueryable();

        #endregion

        #region ScheduleAppointment

        public IMongoCollection<ScheduledAppointment> ScheduledAppointments => CreateCollection<ScheduledAppointment>();

        public IMongoQueryable<ScheduledAppointment> ScheduledAppointmentsAsQueryable => ScheduledAppointments.AsQueryable();

        public IMongoCollection<ScheduledGuest> ScheduledGuests => CreateCollection<ScheduledGuest>();

        public IMongoQueryable<ScheduledGuest> ScheduledGuestsAsQueryable => ScheduledGuests.AsQueryable();

        #endregion

        #region SalesNexus

        public IMongoCollection<SalesNexusLink> SalesNexusLinks => CreateCollection<SalesNexusLink>();

        public IMongoQueryable<SalesNexusLink> SalesNexusLinksAsQueryable => SalesNexusLinks.AsQueryable();

        public IMongoCollection<SalesNexusContact> SalesNexusContacts => CreateCollection<SalesNexusContact>();

        public IMongoQueryable<SalesNexusContact> SalesNexusContactsAsQueryable => SalesNexusContacts.AsQueryable();

        public IMongoCollection<SalesNexusUser> SalesNexusUsers => CreateCollection<SalesNexusUser>();

        public IMongoQueryable<SalesNexusUser> SalesNexusUsersAsQueryable => SalesNexusUsers.AsQueryable();

        public IMongoCollection<SalesNexusField> SalesNexusFields => CreateCollection<SalesNexusField>();

        public IMongoQueryable<SalesNexusField> SalesNexusFieldsAsQueryable => SalesNexusFields.AsQueryable();

        #endregion

        #region EligibilityTest

        public IMongoCollection<EligibilityTestSet> EligibilityTestSets => CreateCollection<EligibilityTestSet>();

        public IMongoQueryable<EligibilityTestSet> EligibilityTestSetsAsQueryable => EligibilityTestSets.AsQueryable();

        public IMongoCollection<EligibilityTestJob> EligibilityTestJobs => CreateCollection<EligibilityTestJob>();

        public IMongoQueryable<EligibilityTestJob> EligibilityTestJobsAsQueryable => EligibilityTestJobs.AsQueryable();

        #endregion

        #region GuestRequestException

        public IMongoCollection<GuestRequestException> GuestRequestExceptions => CreateCollection<GuestRequestException>();

        public IMongoQueryable<GuestRequestException> GuestRequestExceptionsAsQueryable => GuestRequestExceptions.AsQueryable();

        #endregion

        #region CronTrigger

        public IMongoCollection<ScheduleTrigger> ScheduleTriggers => CreateCollection<ScheduleTrigger>();

        public IMongoQueryable<ScheduleTrigger> ScheduleTriggersAsQueryable => ScheduleTriggers.AsQueryable();

        #endregion

        #region LoanDocumentPackage

        public IMongoCollection<LoanDocumentPackage> LoanDocumentPackages => CreateCollection<LoanDocumentPackage>();

        public IMongoQueryable<LoanDocumentPackage> LoanDocumentPackagesAsQueryable => LoanDocumentPackages.AsQueryable();

        #endregion

        #region SecureDoc

        public IMongoCollection<SecureDoc> SecureDocs => CreateCollection<SecureDoc>();

        public IMongoQueryable<SecureDoc> SecureDocsAsQueryable => SecureDocs.AsQueryable();
        
        public IMongoCollection<SecureFolderShare> SecureFolderDetails => CreateCollection<SecureFolderShare>();

        public IMongoQueryable<SecureFolderShare> SecureFolderDetailsAsQueryable => SecureFolderDetails.AsQueryable();

        #endregion

        #region BankStatement

        public IMongoCollection<BankStatementExtractRequest> BankStatementExtractRequests => CreateCollection<BankStatementExtractRequest>();

        public IMongoQueryable<BankStatementExtractRequest> BankStatementExtractRequestsAsQueryable => BankStatementExtractRequests.AsQueryable();

        public IMongoCollection<BankStatementExtractBank> BankStatementExtractBanks => CreateCollection<BankStatementExtractBank>();

        public IMongoQueryable<BankStatementExtractBank> BankStatementExtractBanksAsQueryable => BankStatementExtractBanks.AsQueryable();

        #endregion

        #region Questionnaire

        public IMongoCollection<Questionnaire> Questionnaires => CreateCollection<Questionnaire>();

        public IMongoCollection<QuestionnaireAnswer> QuestionnaireAnswers => CreateCollection<QuestionnaireAnswer>();

        #endregion

        #region MyPipelineFilter

        public IMongoCollection<MyPipelineFilter> MyPipelineFilters => CreateCollection<MyPipelineFilter>();

        #endregion

        #region ClientContact

        public IMongoCollection<ClientContact> ClientContacts => CreateCollection<ClientContact>();

        #endregion
    }
}
