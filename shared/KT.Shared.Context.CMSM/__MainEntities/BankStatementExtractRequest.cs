using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(BankStatementExtractRequest))]
    public partial class BankStatementExtractRequest : KTWrapMongoEntity
    {
        public ObjectId OrganizationId { get; set; }

        public string ReferenceNumber { get; set; }

        public ObjectId? FileShareDataId { get; set; }

        public int? FileNumber { get; set; }

        public int Status { get; set; }

        [BsonIgnoreIfNull]
        public DateTime? VerifiedDate { get; set; }

        [BsonIgnoreIfNull]
        public DateTime? IncompleteDate { get; set; }

        public BankInfo BankInfo { get; set; }

        [BsonIgnoreIfNull]
        public XtractInfo XtractInfo { get; set; }

        [BsonIgnoreIfNull]
        public List<BankStatementDocInfo> DocInfos { get; set; }

        public BankStatementBusinessInfo BusinessInfo { get; set; }

        public BankStatementBorrowerInfo BorrowerInfo { get; set; }

        [BsonIgnoreIfNull]
        public List<BankStatementOwner> Owners { get; set; }

        [BsonIgnoreIfNull]
        public List<BankStatementNote> Notes { get; set; } = new List<BankStatementNote>();
    }

    [Serializable]
    public class BankStatementBorrowerInfo
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherName { get; set; }
        
        public bool? PartyTaxPreparerExpense3rd { get; set; }

        public decimal? BorrowerPercentageOfOwnership { get; set; }

        public decimal? ExpenseRatio { get; set; }
    }

    [Serializable]
    public class BankInfo
    {
        public string BankName { get; set; }

        public int BankType { get; set; }

        public string AccountNumber { get; set; }

        public bool? BusinessBankStatementAvailable { get; set; }

        public string BusinessAccountTypeNote { get; set; }
    }

    [Serializable]
    public class XtractInfo
    {
        public int XtractId { get; set; }

        public List<int> FileIds { get; set; }

        public string Status { get; set; }

        public string ReportId { get; set; }
    }

    [Serializable]
    public class BankStatementDocInfo : KTWrapMongoEntity
    {
        public string Name { get; set; }

        public string Extension { get; set; }

        public int Size { get; set; }

        public int? XtractFileId { get; set; }

    }

    [Serializable]
    public class BankStatementBusinessInfo
    {
        public string BusinessName { get; set; }

        public string CompanyName { get; set; }

        public bool? PartyTaxPreparerExpense3rd { get; set; }

        public decimal? BorrowerPercentageOfOwnership { get; set; }

        public decimal? ExpenseRatio { get; set; }
    }


    [Serializable]
    public class BankStatementOwner : KTWrapMongoEntity
    {
        public ObjectId UserId { get; set; }

        public bool IsProcessor { get; set; }//IsProcessor = true => this user is Processor of request

    }

    [Serializable]
    public class BankStatementNote : KTWrapMongoEntityId
    {
        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public ObjectId CreatedBy { get; set; }

        public bool IsFromSendEmail { get; set; }

    }

}
