using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    public class BusinessFileLoanWise
    {
        public DateTime? LastRun { get; set; }

        public ObjectId? LastRunBy { get; set; }

        public string RuleValuesAsJson { get; set; }

        public List<RuleResultItem> RuleResults { get; set; } = new List<RuleResultItem>();

        public class RuleResultItem
        {
            public ObjectId StipulationId { get; set; }

            public string StipulationName { get; set; }

            public int CategoryId { get; set; }

            public string CategoryName { get; set; }

            public bool IsUnderwritingCheckList { get; set; }

            public List<string> Messages { get; set; } = new List<string>();
        }
    }
}
