using KT.Shared.Context.CMSM.BA;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public class BusinessFileBrokerCompany
    {

        public string AccountExecutive { get; set; }
        public string AccountExecutiveEmail { get; set; }
        public string Name { get; set; }
        public string NMLSID { get; set; }
        public string Address { get; set; }
        public string Ste { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string PrimaryContactPhone { get; set; }
        public string PrimaryContactEmail { get; set; }
        public string IncorpOrOrgState { get; set; }
        public DateTime? DateFormed { get; set; }
        public string BusinessTaxId { get; set; }

        public int? BusinessEntityType { get; set; }

        public List<MortgageLoanOriginator> MortgageLoanOriginators { get; set; } = new List<MortgageLoanOriginator>();

        public List<OwnershipOrManagement> OwnershipOrManagements { get; set; } = new List<OwnershipOrManagement>();

        public List<StateLicense> StateLicenses { get; set; } = new List<StateLicense>();

        public List<AdditionalBranch> AdditionalBranches { get; set; } = new List<AdditionalBranch>();
    }
    
}
