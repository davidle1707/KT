using KT.Shared.Context.CMSM.Utils;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public class BusinessFileUnderwritingCondition
    {
        public List<BusinessFileUnderwritingConditionItem> Conditions { get; set; }
    }

    [Serializable]
    public class BusinessFileUnderwritingConditionItem : KTWrapMongoEntityId, IKTWrapCheckListItem
    {
        public int TypeId { get; set; }

        [BsonIgnoreIfNull]
        public int? Index { get; set; }

        [LendingQbField("Category", "UnderwritingCondition", IsLoad = true)] 
        public string Category { get; set; }

        [LendingQbField("DueDate", "UnderwritingCondition", IsLoad = true)]
        [BsonIgnoreIfNull]
        public DateTime? DueDate { get; set; }

        [BsonIgnoreIfNull]
        public DateTime? SubmittedDate { get; set; }

        [LendingQbField("CondDesc", "UnderwritingCondition", IsLoad = true)] 
        public string Detail { get; set; }

        [LendingQbField("Status", "UnderwritingCondition", IsLoad = true)] 
        public string UWStatus { get; set; }

        public DateTime CreatedDate { get; set; }

        [LendingQbField("DoneDate", "UnderwritingCondition", IsLoad = true)]
        [BsonIgnoreIfNull]
        public DateTime? DoneDate { get; set; }

        [LendingQbField("AssignedTo", "UnderwritingCondition", IsLoad = true)]
        [BsonIgnoreIfNull]
        public string AssignedTo { get; set; }

        public List<ObjectId> DocumentIds { get; set; }

        [BsonIgnoreIfNull]
        public string QuickNote { get; set; }

        [BsonIgnoreIfNull]
        public ObjectId? StipulationId { get; set; }

        [BsonIgnoreIfNull]
        public ObjectId? StipulationConditionId { get; set; }

        #region IKTWrapCheckListItem

        public string ListItemId => Id.ToString();

        public string ListItemName => $"{Category} - {Id}";

        #endregion
    }
}
