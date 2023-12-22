
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
	[Serializable]
	public class Borrower : KTWrapMongoEntityId
    {
        public Borrower()
        {
            Id = ObjectId.GenerateNewId();
        }

		public BorrowerInfo Info { get; set; } = new BorrowerInfo();

        [BsonIgnoreIfNull]
        public BorrowerEmployment Employment { get; set; }

        [BsonIgnoreIfNull]
        public BorrowerCredit Credit { get; set; }

        [BsonIgnoreIfNull]
        public BorrowerIncome Income { get; set; }

        [BsonIgnoreIfNull]
        public BorrowerDeclaration Declaration { get; set; }

        [BsonIgnoreIfNull]
        public BorrowerDerogatorySummary DerogatorySummary { get; set; }

        public List<BorrowerAsset> Assets { get; set; } = new List<BorrowerAsset>();

        public List<BorrowerLiability> Liabilities { get; set; } = new List<BorrowerLiability>();

        public List<BorrowerRESchedule> RESchedules { get; set; } = new List<BorrowerRESchedule>();

        public List<BorrowerCreditScore> CreditScores { get; set; } = new List<BorrowerCreditScore>();

        public List<BorrowerResidenceInfo> Residences { get; set; } = new List<BorrowerResidenceInfo>();

        public List<BorrowerOccupationInfo> Occupations { get; set; } = new List<BorrowerOccupationInfo>();

        [BsonIgnoreIfNull]
        public List<BorrowerCreditPublicRecord> PublicRecords { get; set; } = new List<BorrowerCreditPublicRecord>();
    }
}
