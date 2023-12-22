using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [BsonDiscriminator(Required = true)]
    [KTWrapMongoCollectionName(typeof(GlobalSetting))]
    public partial class GlobalSetting : KTWrapMongoEntity
    {
        [Serializable]
        public class OrgEmail
        {
            public ObjectId OrgId { get; set; }

            public string Address { get; set; }

            public string DisplayName { get; set; }
        }

        [Serializable]
        public class OrgSms
        {
            public ObjectId OrgId { get; set; }

            public string PhoneNumber { get; set; }
        }
    }

    #region SupportTicket

    [BsonKnownTypes(typeof(SupportTicket))]
    public partial class GlobalSetting
    {
        [Serializable]
        [BsonDiscriminator(nameof(SupportTicket), Required = true)]
        public partial class SupportTicket : GlobalSetting
        {
            public long ReferenceNumber { get; set; }

            public bool ReplyUserAfterSubmit { get; set; }

            public bool NotifyUserWhenSupportReply { get; set; }

            public bool NotifyUserWhenChangeStatus { get; set; }

            public List<OrgEmail> Emails { get; set; } = new List<OrgEmail>();

            public List<OrgSms> Sms { get; set; } = new List<OrgSms>();
        }
    }

    #endregion

    #region BrokerPortalLink

    [BsonKnownTypes(typeof(BrokerPortalLink))]
    public partial class GlobalSetting
    {
        [Serializable]
        [BsonDiscriminator(nameof(BrokerPortalLink), Required = true)]
        public class BrokerPortalLink : GlobalSetting
        {
            public ObjectId OrgId { get; set; }

            public ObjectId StageId { get; set; }
        }
    }

    #endregion

    #region Login

    [BsonKnownTypes(typeof(Login))]
    public partial class GlobalSetting
    {
        [Serializable]
        [BsonDiscriminator(nameof(Login), Required = true)]
        public class Login : GlobalSetting
        {
            public List<OrgEmail> NotifyEmails { get; set; } = new List<OrgEmail>();
        }
    }

    #endregion

    #region Eligibility

    [BsonKnownTypes(typeof(Eligibility))]
    public partial class GlobalSetting
    {
        [Serializable]
        [BsonDiscriminator(nameof(Eligibility), Required = true)]
        public partial class Eligibility : GlobalSetting
        {
            public int RequestRateLockValidateEndHourInDay { get; set; } = 13;

            public ProductGroupLinkDocType[] ProductGroupLinkDocTypes { get; set; }
        }

        public partial class Eligibility
        {
            [Serializable]
            public class ProductGroupLinkDocType
            {
                public string ProductGroup { get; set; }

                public string DocTypes { get; set; }
            }
        }
    }

    #endregion

    #region KeyValue

    [BsonKnownTypes(typeof(KeyValue))]
    public partial class GlobalSetting
    {
        [BsonDiscriminator(nameof(KeyValue), Required = true), Serializable]
        public class KeyValue : GlobalSetting
        {
            public Dictionary<string, string> Data { get; set; } = new Dictionary<string, string>();
        }
    }

    #endregion

    #region SequenceLong

    [BsonKnownTypes(typeof(SequenceItem))]
    public partial class GlobalSetting
    {
        [BsonDiscriminator(nameof(SequenceItem), Required = true), Serializable]
        public class SequenceItem : GlobalSetting
        {
            public Dictionary<string, long> Items { get; set; } = new Dictionary<string, long>();
        }
    }

    #endregion
}
