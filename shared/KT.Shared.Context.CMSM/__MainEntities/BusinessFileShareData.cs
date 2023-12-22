using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName("BusinessFileShareData")]
    public class BusinessFileShareData : FileAppShare
    {
        public BusinessFileShareData(ObjectId id, ObjectId? createdBy = null) : this()
        {
            Id = id;
            CreatedBy = createdBy;
            CreatedDate = DateTime.UtcNow;
        }

        public BusinessFileShareData() { }

        public BusinessFileBorrower PrimaryBorrower { get; set; } = new BusinessFileBorrower();

        public List<BusinessFileBorrower> CoBorrowers { get; set; } = new List<BusinessFileBorrower>();

        [BsonIgnoreIfNull]
        public BusinessFileMortgage Mortgage { get; set; }

        [BsonIgnoreIfNull]
        public BusinessFileProperty Property { get; set; }

        public List<BusinessFileDocument> Documents { get; set; } = new List<BusinessFileDocument>();

        [BsonIgnoreIfNull]
        public BusinessFileLoanWise LoanWise { get; set; }

        [BsonIgnoreIfNull]
        public BusinessFileUnderwritingCondition UnderwritingCondition { get; set; }

        public List<BusinessFileFee> Fees { get; set; } = new List<BusinessFileFee>();

        [BsonIgnoreIfNull]
        public BusinessFileBrokerCompany BrokerCompany { get; set; }

        [BsonIgnoreIfNull]
        public BusinessFileContactInfo ContactInfo { get; set; }

        [BsonIgnoreIfNull]
        public List<BusinessFileChangeOfCircumstance> ChangeOfCircumstances { get; set; } = new List<BusinessFileChangeOfCircumstance>();

        [BsonIgnoreIfNull]
        public ObjectId? BrokerPortalAppId { get; set; }

        [BsonIgnoreIfNull]
        public BusinessFileBrokerApprovalProcess BrokerApprovalProcess { get; set; }

        [BsonIgnoreIfNull]
        public BusinessFileExceptionRequest ExceptionRequest { get; set; }

        [BsonIgnoreIfNull]
        public BusinessFileDocumentLoanData DocumentLoanData { get; set; }

        [BsonIgnoreIfNull]
        public BusinessFileSubmissionForm SubmissionForm { get; set; }

        public BusinessFileLockProgram LockProgram { get; set; } = new BusinessFileLockProgram();

        [BsonIgnoreIfNull]
        public BusinessFileCheckList CheckList { get; set; }

        [BsonIgnoreIfNull]
        public BusinessFileDynamicValue DynamicValue { get; set; }
    }
}