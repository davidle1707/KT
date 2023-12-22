using System;
using System.Collections.Generic;
using System.Text;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(OrganizationLosSubmit))]
    public class OrganizationLosSubmit : KTWrapMongoEntity
    {
        public int LosOrganizationId { get; set; }

        public int LosParentOrganizationId { get; set; }

        public short LosOrganizationType { get; set; }

        public int LosStatus { get; set; }

        public List<StateLicense> StateLicenses { get; set; } = new List<StateLicense>();

        public List<User> Users { get; set; } = new List<User>();

        public class User : KTWrapMongoEntityId
        {
            public int LosUserId { get; set; }

            public int LosRoleId { get; set; }

        }

        public class StateLicense : KTWrapMongoEntityId
        {
            public int LosStateLicenseId { get; set; }
        }
    }
}
