using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(PortalSetting))]
    public abstract partial class PortalSetting : KTWrapMongoEntity
    {
        public ObjectId OrganizationId { get; set; }

        public ObjectId? BranchId { get; set; }

    }

    [BsonDiscriminator(Required = true)]
    [BsonKnownTypes(typeof(DocCheckListHtml), typeof(ShowAgentRole))]
    public abstract partial class PortalSetting
    {

        #region DocCheckListHTMlSetting

        [Serializable]
        [BsonDiscriminator(nameof(DocCheckListHtml), Required = true)]
        public class DocCheckListHtml : PortalSetting
        {
            public string DocumentCheckListValue { get; set; }
        }

        #endregion

        #region ShowAgentRole

        [Serializable]
        [BsonDiscriminator(nameof(ShowAgentRole), Required = true)]
        public class ShowAgentRole : PortalSetting
        {
            public ObjectId RoleId { get; set; }
        }

        #endregion

    }
}
