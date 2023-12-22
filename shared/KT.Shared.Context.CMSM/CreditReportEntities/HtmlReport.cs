using System;

namespace KT.Shared.Context.CMSM.CreditReportEntities
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(HtmlReport))]
    public class HtmlReport : KTWrapMongoEntity
    {
        public string Content { get; set; }
    }

}
