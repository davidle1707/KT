using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(BusinessFileProgram))]
    public class BusinessFileProgram : KTWrapMongoEntity
    {
        public ObjectId FileId { get; set; }

        public ObjectId ShareDataId { get; set; }

        public BusinessFileUsedProgram Used { get; set; } = new BusinessFileUsedProgram();

        public List<BusinessFileCheckedProgramHistory> CheckedHistories { get; set; } = new List<BusinessFileCheckedProgramHistory>();

        public List<BusinessFileUsedProgramHistory> UsedHistories { get; set; } = new List<BusinessFileUsedProgramHistory>();

        [BsonIgnoreIfNull]
        public BusinessFileBackupUsedProgram BackupUsed { get; set; }
    }

    [Serializable]
    public class BusinessFileUsedProgram
    {
        [BsonIgnoreIfNull]
        public LoanProduct Product { get; set; }

        [BsonIgnoreIfNull]
        public RateSheet Rate { get; set; }

        [BsonIgnoreIfNull]
        public Fee Fee { get; set; }
    }

    [Serializable]
    public class BusinessFileCheckedProgramHistory : KTWrapMongoEntityId
    {
        public DateTime CreatedDate { get; set; }

        public EligibilityMortgage Mortgage { get; set; } = new EligibilityMortgage();

        public EligibilityCredit Credit { get; set; } = new EligibilityCredit();

        public EligibilityEmployment Employment { get; set; } = new EligibilityEmployment();
    }

    [Serializable]
    public class BusinessFileUsedProgramHistory : KTWrapMongoEntityId
    {
        public DateTime CreatedDate { get; set; }

        public ObjectId? CreatedBy { get; set; }

        public ObjectId ProgramId { get; set; }

        public string ProgramName { get; set; }

        public decimal Rate { get; set; }

        public decimal Point { get; set; }

        public decimal OriginationFee { get; set; }

        public decimal TotalFees { get; set; }

        public double Price { get; set; }

        public double PriceOriginal { get; set; }

        public double LLPA { get; set; }

        public double PI { get; set; }

        public double APR { get; set; }

        public bool? HighCost { get; set; }

        public bool? IsException { get; set; }

        public EligibilityMortgage Mortgage { get; set; } = new EligibilityMortgage();

        public EligibilityCredit Credit { get; set; } = new EligibilityCredit();

        public EligibilityEmployment Employment { get; set; } = new EligibilityEmployment();
    }

    public class BusinessFileBackupUsedProgram : KTWrapMongoEntityId
    {
        public BusinessFileUsedProgram Used { get; set; }

        public UsedProgramCalculated Calculated { get; set; }
    }

}
