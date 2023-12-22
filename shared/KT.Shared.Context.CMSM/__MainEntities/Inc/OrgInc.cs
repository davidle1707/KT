using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public class ConsumerPortalSetting
    {
        public string Domain { get; set; }
    }

    [Serializable]
    public class LendingQBSetting
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool AutoSync { get; set; }

        public bool AutoSyncUnderwritingConditionDocumnents { get; set; }
    }

    [Serializable]
    public class ByteProSetting
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Session { get; set; }

        public string OrganizationCode { get; set; }
    }

    [Serializable]
    public class CreditReportSetting
    {
        public List<string> Providers { get; set; } = new List<string>();

        [BsonIgnoreIfNull]
        public MeridianLinkInfo MeridianLink { get; set; }

        [BsonIgnoreIfNull]
        public SoftPullInfo SoftPull { get; set; }

        [BsonIgnoreIfNull]
        public SettingISoftPullInfo ISoftPull { get; set; } = new SettingISoftPullInfo();

        [Serializable]
        public class MeridianLinkInfo
        {
            public string Url { get; set; }

            public string Identifier { get; set; }

            public string UserName { get; set; }

            public string Password { get; set; }

            public bool IsDebugMode { get; set; }

            public bool EnableProxy { get; set; }

            public string ProxyServer { get; set; }

            public int ProxyPort { get; set; }

            public bool ProxyIsHttps { get; set; }
        }

        [Serializable]
        public class SoftPullInfo
        {
            public string Url { get; set; }

            public string AccessToken { get; set; }
        }

        [Serializable]
        public class SettingISoftPullInfo
        {
            public int? LenderId { get; set; }

            public string Url { get; set; }

            public string UserName { get; set; }

            public string Password { get; set; }

            public string GroupCode { get; set; }
        }

    }

    [Serializable]
    public class MenuConfigOrg
    {
        public ObjectId Id { get; set; }

        [BsonIgnoreIfNull]
        public string MenuTitle { get; set; }

        [BsonIgnoreIfNull]
        public string MenuDescription { get; set; }

        public int MenuType { get; set; }

        public bool IsShowInConfig { get; set; }

        public int MenuIndex { get; set; }
    }

    [Serializable]
    public class ActionMenuConfigOrg
    {
        public ObjectId Id { get; set; }

        [BsonIgnoreIfNull]
        public string ActionMenuTitle { get; set; }

        [BsonIgnoreIfNull]
        public string ActionMenuDescription { get; set; }

        public int ActionMenuType { get; set; }

        public bool IsShowInConfig { get; set; }

        public int ActionMenuIndex { get; set; }
    }

    [Serializable]
    public class SectionConfigOrg
    {
        public ObjectId Id { get; set; }

        [BsonIgnoreIfNull]
        public string SectionTitle { get; set; }

        [BsonIgnoreIfNull]
        public string SectionDescription { get; set; }

        public int SectionType { get; set; }

        public bool IsShowInConfig { get; set; }

        public int SectionIndex { get; set; }
    }

    [Serializable]
    public class OrgLoanProductSetting
    {
        public ObjectId OrgId { get; set; }

        public List<int> GroupIds { get; set; } = new List<int>();

        public List<ObjectId> ProductIds { get; set; } = new List<ObjectId>();
    }

    [Serializable]
    public class ReportSetting
    {
        public List<AvailableReport> Availables { get; set; } = new List<AvailableReport>();

        [Serializable]
        public class AvailableReport
        {
            public int Type { get; set; }

            public string Name { get; set; }
        }
    }

    [Serializable]
    public class BankStatementOrgSetting
    {
        public string XtractApiUrl { get; set; }

        public string XtractApiKey { get; set; }
    }

    [Serializable]
    public class ExceptionRequestAllowEditFieldConfigOrg
    {
        public ObjectId Id { get; set; }

        public string FieldName { get; set; }

        public string FullFieldName { get; set; }

        public bool IsAllowEdit { get; set; }

    }

    [Serializable]
    public class PhoneCallRecordingSetting
    {
        public string ApiUrl { get; set; }
                
        public string ApiKey { get; set; }
    }

    [Serializable]
    public class OrgLicense
    {
        public string NMLS { get; set; }

        public string TaxId { get; set; }

        public List<OrgStateLicense> StateLicenses { get; set; } = new List<OrgStateLicense>();
    }

    [Serializable]
    public class OrgStateLicense
    {
        public ObjectId Id { get; set; }

        public string State { get; set; }

        public string LicenseNo { get; set; }

        [BsonIgnoreIfNull, BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? StartDate { get; set; }

        [BsonIgnoreIfNull, BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? ExpirationDate { get; set; }
    }

}
