using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public class LosLoanLog : KTWrapMongoEntityId
    {
        public DateTime LoggedDate { get; set; }

        [BsonIgnoreIfNull]
        public ObjectId? LoggedBy { get; set; }

        public string Status { get; set; }

        public string Message { get; set; }
    }

    #region LendingQB

    [Serializable]
    public class LendingQbAssetRef : KTWrapMongoEntityId
    {
        public ObjectId BorrowerId { get; set; }

        public string LqbAssetId { get; set; }

    }

    [Serializable]
    public class LendingQbBorrowerRef : KTWrapMongoEntityId
    {
        public ObjectId BusinessFileBorrowerId { get; set; }

        public string ConsumerId { get; set; }
    }

    [Serializable]
    public class LendingQbDocumentRef : KTWrapMongoEntityId
    {
        public string LqbDocumentId { get; set; }
    }

    [Serializable]
    public class LendingQbEmpRecordRef : KTWrapMongoEntityId
    {
        public ObjectId BorrowerId { get; set; }

        public string LqbEmpRecordId { get; set; }
    }

    [Serializable]
    public class LendingQbHousingHisEntryRef : KTWrapMongoEntityId
    {
        public string LqbHHEntryId { get; set; }

        public ObjectId BorrowerId { get; set; }
    }

    [Serializable]
    public class LendingQbIncomeRef : KTWrapMongoEntityId
    {
        public ObjectId BorrowerId { get; set; }

        public string LqbIncomeSourceId { get; set; }

        public int IncomeType { get; set; }
    }

    [Serializable]
    public class LendingQbLiabilityRef : KTWrapMongoEntityId
    {
        public ObjectId BorrowerId { get; set; }

        public string LqbLiabilityId { get; set; }
    }

    [Serializable]
    public class LendingQbRealPropertyRef : KTWrapMongoEntityId
    {
        public ObjectId BorrowerId { get; set; }

        public string LqbRealPropertyId { get; set; }
    }

    [Serializable]
    public class LendingQbUwConditionRef : KTWrapMongoEntityId
    {
        public string LqbUwConditionId { get; set; }
    }

    #endregion

    #region BytePro

    [Serializable]
    public class ByteProBorrowerRef : KTWrapMongoEntityId
    {
        public ObjectId BusinessFileBorrowerId { get; set; }

        public int BpApplicationId { get; set; }

        public int BpApplicationOrder { get; set; }

        public int BpBorrowerId { get; set; }

    }

    [Serializable]
    public class ByteProAssetRef : KTWrapMongoEntityId
    {
        public ObjectId BorrowerId { get; set; }

        public int BpAssetId { get; set; }

        public int BpBorrowerId { get; set; }

    }

    [Serializable]
    public class ByteProEmployerRef : KTWrapMongoEntityId
    {
        public ObjectId BorrowerId { get; set; }

        public int BpEmployerId { get; set; }

        public int BpBorrowerId { get; set; }
    }

    [Serializable]
    public class ByteProResidenceRef : KTWrapMongoEntityId
    {
        public ObjectId BorrowerId { get; set; }

        public int BpResidenceId { get; set; }

        public int BpBorrowerId { get; set; }
    }

    [Serializable]
    public class ByteProIncomeRef : KTWrapMongoEntityId
    {
        public ObjectId BorrowerId { get; set; }

        public int BpIncomeId { get; set; }

        public int BpBorrowerId { get; set; }

        public int BpIncomeType { get; set; }
    }

    [Serializable]
    public class ByteProDebtRef : KTWrapMongoEntityId
    {
        public ObjectId BorrowerId { get; set; }

        public int BpDebtId { get; set; }

        public int BpBorrowerId { get; set; }
    }

    [Serializable]
    public class ByteProREORef : KTWrapMongoEntityId
    {
        public ObjectId BorrowerId { get; set; }

        public int BpREOId { get; set; }

        public int BpBorrowerId { get; set; }
    }

    [Serializable]
    public class ByteProConditionRef : KTWrapMongoEntityId
    {
        public int BpConditionId { get; set; }
    }

    [Serializable]
    public class ByteProDocumentRef : KTWrapMongoEntityId
    {
        public int BpDocumentId { get; set; }
    }

    [Serializable]
    public class ByteProPrepaidItemRef : KTWrapMongoEntityId
    {
        public int BpPrepaidItemId { get; set; }

        public int BpPrepaidItemType { get; set; }

        public int BpDisbursementSched { get; set; }

        public int BpDisbursementStartPur { get; set; }

        public int BpPremiumPaidToType { get; set; }

    }

    [Serializable]
    public class ByteProExtFieldRef : KTWrapMongoEntityId
    {
        public int BpExtFieldId { get; set; }

        public string BpExtFieldName { get; set; }

        [BsonIgnoreIfNull]
        public int? ExceptionIndex { get; set; }

    }

    [Serializable]
    public class ByteProPriceAdjustmentRef : KTWrapMongoEntityId
    {
        public int BpPriceAdjId { get; set; }

    }

    #endregion

}
