using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM.BA
{
    [Serializable]
    public class BrokerCompany
    {
        public string AccountExecutive { get; set; }

        public string AccountExecutiveEmail { get; set; }

        public ObjectId? AccountExecutiveUserId { get; set; }

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

        public string PrimaryContactFirstName { get; set; }

        public string PrimaryContactLastName { get; set; }

        public string PrimaryContactPhone { get; set; }

        public string PrimaryContactEmail { get; set; }

        public string IncorpOrOrgState { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? DateFormed { get; set; }

        public string BusinessTaxId { get; set; }

        //new fields
        public string BrokerName { get; set; }
        public int? BrokerTitle { get; set; }
        public string BrokerSSN { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? BrokerDate { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? BrokerEffectiveDate { get; set; }
        public string LoanWyseAuthorizedPerson { get; set; }
        public string LoanWyseTitle { get; set; }
        public string CorporationAuthorizedPerson { get; set; }
        public string CorporationTitle { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? CorporationEffectiveDate { get; set; }
                
        public string BrokerAddress { get; set; }
        
        public string BrokerAddress2 { get; set; }

        public string PresidentTitle { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? BrokerDOB { get; set; }

        #region Authen

        public string Password { get; set; }

        public int Status { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public ObjectId? OTPTransactionId { get; set; }

        #endregion
    }
}
