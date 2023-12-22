using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM.BA
{
    [Serializable]
    [BsonDiscriminator(nameof(FormW9), Required = true)]
    public sealed class FormW9 : BaseStep
    {
        public string Name { get; set; }
        public string BusinessName { get; set; }
        public int FederalTaxClassification { get; set; }
        
        public string TaxClassification { get; set; }
        
        public string OtherRemark { get; set; }

        public string ExemptPayeeCode { get; set; }
        public string FATCAReportingCode { get; set; }

        public string Address { get; set; }
        public string CityStateZipCode { get; set; }
        public string ListAccountNumber { get; set; }

        public string SSN { get; set; }
        public string EmployerIdentificationNumber { get; set; }
        public DateTime? Date { get; set; }

    }
}
