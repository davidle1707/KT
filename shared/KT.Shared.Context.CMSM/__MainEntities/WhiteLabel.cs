using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(WhiteLabel))]
    public class WhiteLabel : KTWrapMongoEntity
    {
        public int LoginType { get; set; } = 1; // CMSM

        public List<ObjectId> OrgIds { get; set; } = new List<ObjectId>();

        public string DomainName { get; set; }

        public string CopyrightName { get; set; }

        public bool IsActive { get; set; }

        public string AuthenLogoExt { get; set; }

        public string SiteLogoExt { get; set; }

        public bool EnableHttps { get; set; }

        public string PageTitle { get; set; }

        public ObjectId? WysePricerUseProductsOrgId { get; set; }

        public ObjectId? WyseGuysOrgId { get; set; }
    }
}
