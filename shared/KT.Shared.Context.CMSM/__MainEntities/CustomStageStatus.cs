using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(CustomStageStatus))]
    public partial class CustomStageStatus : KTWrapMongoEntity, IIdName
    {
        public string Name { get; set; }

        public int Index { get; set; }

        public ObjectId CustomStageId { get; set; }

        public bool IsUnassigned { get; set; }

        public SettingInfos Settings { get; set; } = new SettingInfos();

        public List<ReasonItem> Reasons { get; set; } = new List<ReasonItem>();
    }

    public partial class CustomStageStatus
    {
        [Serializable]
        public class SettingInfos
        {
            public bool IsNewLoanSubmission { get; set; }

            public bool IsSubmitLoan { get; set; }

            public bool IsRegistered { get; set; }

            public bool IsIncompleteRegistration { get; set; }

            public bool HasReasons { get; set; }
        }

        [Serializable]
        public class ReasonItem
        {
            public string Reason { get; set; }

            public string Description { get; set; }
        }
    }
}