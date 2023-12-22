using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(CGIPostLog))]
    public class CGIPostLog : KTWrapMongoEntity
    {
        public int Type { get; set; }

        public string Status { get; set; }

        public string Domain { get; set; }

        public string PostedIp { get; set; }

        public string QueryString { get; set; }

        public string FormData { get; set; }

        #region FileApp

        public ObjectId? SettingId { get; set; }

        public ObjectId? OrganizationId { get; set; }

        public int? BusinessType { get; set; }

        public ObjectId? CreatedBusinessFileId { get; set; }

        public ObjectId? AssignedToUserId { get; set; }

        #endregion

        #region SalesNexus

        public string  SalesNexusContactId { get; set; }

        #endregion

    }
}
