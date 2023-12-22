using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace KT.Shared.Context.CMSM.PaymentEntities
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(User))]
    public class User : KTWrapMongoEntity
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public List<ObjectId> AccountIds { get; set; } = new List<ObjectId>();

        public List<ObjectId> CmsmOrgIds { get; set; } = new List<ObjectId>();

        public string Email { get; set; }

        public string CellPhone { get; set; }

        public string SSN4 { get; set; }

        public ObjectId? OtpTransactionId { get; set; }

        // more ...
    }
}
