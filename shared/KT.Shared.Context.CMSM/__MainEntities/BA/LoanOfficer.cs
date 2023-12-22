using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM.BA
{
    [Serializable]
    [BsonDiscriminator(nameof(LoanOfficer), Required = true)]
    public sealed class LoanOfficer : BaseStep
    {
        public bool UseAuthenOTP { get; set; }
        public List<LoanOfficerDetail> LoanOfficerDetails { get; set; } = new List<LoanOfficerDetail>();
    }

    [Serializable]
    public class LoanOfficerDetail : KTWrapMongoEntityId
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Role { get; set; }
        public string NMLSNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
