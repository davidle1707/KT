using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM.BA
{
    [Serializable]
    [BsonDiscriminator(nameof(InitialApplication), Required = true)]
    public sealed class InitialApplication : BaseStep
    {
        public int? BusinessEntityType { get; set; }

        public bool UseOtherEntity { get; set; }

        public string IndicateNameOfOtherEntity { get; set; }

        public string FundWarehouseLine { get; set; }

        public bool DSCRStateExemption { get; set; }

        public List<MortgageLoanOriginator> MortgageLoanOriginators { get; set; } = new List<MortgageLoanOriginator>();

        public List<OwnershipOrManagement> OwnershipOrManagements { get; set; } = new List<OwnershipOrManagement>();

        public List<StateLicense> StateLicenses { get; set; } = new List<StateLicense>();

        public List<AdditionalBranch> AdditionalBranches { get; set; } = new List<AdditionalBranch>();

        public List<ReferencesAndCompanyVolume> ReferencesAndCompanyVolumes { get; set; } = new List<ReferencesAndCompanyVolume>();

        public List<WarehouseLine> WarehouseLines { get; set; } = new List<WarehouseLine>();
    }

    [Serializable]
    public class MortgageLoanOriginator : KTWrapMongoEntityId
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NMLSNumber { get; set; }
        public int? Title { get; set; }
        public string ContactEmail { get; set; }
        public string SSN { get; set; }
    }

    [Serializable]
    public class OwnershipOrManagement : KTWrapMongoEntityId
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NMLSNumber { get; set; }
        public string Title { get; set; }
        public string ContactEmail { get; set; }
        public string SSN { get; set; }
        public double OwnerPercent { get; set; }
    }

    [Serializable]
    public class StateLicense : KTWrapMongoEntityId
    {
        public string State { get; set; }
        public string LicensceNumber { get; set; }
        public int Status { get; set; }
        public DateTime? ExpDate { get; set; }
        public string LicenseType { get; set; }
    }

    [Serializable]
    public class AdditionalBranch : KTWrapMongoEntityId
    {
        public string State { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string BranchManager { get; set; }
        public string Phone { get; set; }
    }

    [Serializable]
    public class ReferencesAndCompanyVolume : KTWrapMongoEntityId
    {
        public string Company { get; set; }
        public string LoanType { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    [Serializable]
    public class WarehouseLine : KTWrapMongoEntityId
    {
        public string WarehouseProvider { get; set; }
        public double LineAmount { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
    }
}
