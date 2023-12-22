using MongoDB.Bson.Serialization.Attributes;
using System;


namespace KT.Shared.Context.CMSM
{
	[Serializable]
    public class BorrowerInfo
	{
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        public string Aka { get; set; }

        public string SSN { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? DOB { get; set; }
        
        public string PersonalEmail { get; set; }
        
        public string WorkEmail { get; set; }
        
        public string PreferEmail { get; set; }
        
        public string Address { get; set; }

        public string HouseNumber { get; set; }

        public string City { get; set; }
        
        public string State { get; set; }
        
        public string ZipCode { get; set; }
        
        public string MiddleName { get; set; }
        
        public string MaritalStatus { get; set; }

        public string HomePhone { get; set; }

        public string WorkPhone { get; set; }

        public string CellPhone { get; set; }

        public string DriverLicenseNo { get; set; }

        public string LicenseState { get; set; }

        public bool PreferHomePhone { get; set; }

        public bool PreferCellPhone { get; set; }

        public bool PreferWorkPhone { get; set; }

        public string PreferFaxNumber { get; set; }

        public int Dependents { get; set; }

        public string AgeOfDependents { get; set; }

        public bool IsUSVeteran { get; set; }

        public int? NumberOfPropertiesOwned { get; set; }

        public decimal BankBalance { get; set; }

        public bool IsInvestment { get; set; }

        public string BankAssetName { get; set; }

        public decimal InvestmentAmount { get; set; }

        public string FormerLastName { get; set; }

        public string BirthPlace { get; set; }

        public string NameOfCurrentSpouse { get; set; }

        public string NameOfFormerSpouse { get; set; }

        public string BusinessTransaction { get; set; }

        public string ReasonsForSSA { get; set; }

        public string AgentInfo { get; set; }

        public string Relationship { get; set; }

        public string CreditCardName { get; set; }

        public int? CreditCardType { get; set; }

        public string CreditCardNumber { get; set; }

        public int CreditCardExpMonth { get; set; }

        public int CreditCardExpYear { get; set; }

        public string CreditCardSecurityCode { get; set; }

        public string BillingAddress { get; set; }

        public string BillingCity { get; set; }

        public string BillingState { get; set; }

        public string BillingZipCode { get; set; }

        public string MobileCarrier { get; set; }

        public string Suffix { get; set; }

        public int Age { get; set; }

        public int SchoolYears { get; set; }

        public string PresentAddressStatus { get; set; }

        public int YearAtPresentAddress { get; set; }

        public string MailingAddressSource { get; set; }

        public string MailingAddress { get; set; }

        public string MailingCity { get; set; }

        public string MailingState { get; set; }

        public string MailingZipCode { get; set; }

        public bool IsNonOccupant { get; set; }

        public string BestTimeToCall { get; set; }

    }
}
