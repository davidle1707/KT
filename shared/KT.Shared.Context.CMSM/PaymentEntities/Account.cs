using KT.Shared.Context.CMSM.PaymentEntities.Inc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KT.Shared.Context.CMSM.PaymentEntities
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(Account))]
    public class Account : KTWrapMongoEntity
    {
        public string LoanProvider { get; set; }

        public string LoanNumber { get; set; }

        public BorrowerInfo BorrowerInfo { get; set; } = new BorrowerInfo();

        public BorrowerInfo CoBorrowerInfo { get; set; }

        public PropertyInfo PropertyInfo { get; set; } = new PropertyInfo();

        public ObjectId? UserId { get; set; }

        public DateTime? PaymentDate { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal PaymentAmount { get; set; }

        public ObjectId? CmsmFileShareDataId { get; set; }

        public CmsmFileInfo CmsmFile { get; set; }

        public int AccountType { get; set; }

        // more ...
    }

    [Serializable]
    public class BorrowerInfo
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string CellPhone { get; set; }

        public string Email { get; set; }

        public string SSN { get; set; }

        public string SSN4 { get; set; } // show only last 4 digits ssn

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string MailingAddress { get; set; }

        public string MailingCity { get; set; }

        public string MailingState { get; set; }

        public string MailingZipCode { get; set; }
    }

    [Serializable]
    public class PropertyInfo
    {
        public string Street { get; set; }

        public string Unit { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }
    }
}
