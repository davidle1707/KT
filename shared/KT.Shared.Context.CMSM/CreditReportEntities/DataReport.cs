using System;

namespace KT.Shared.Context.CMSM.CreditReportEntities
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(DataReport))]
    public class DataReport : KTWrapMongoEntity
    {
        public string Source { get; set; }

        public string Content { get; set; }

    }
}
