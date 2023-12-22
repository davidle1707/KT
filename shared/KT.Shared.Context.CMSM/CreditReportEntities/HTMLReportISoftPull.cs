using System;
using System.Collections.Generic;
using System.Text;

namespace KT.Shared.Context.CMSM.CreditReportEntities
{
    [Serializable, KTWrapMongoCollectionName(typeof(HTMLReportISoftPull))]
    public class HTMLReportISoftPull : KTWrapMongoEntity
    {
        public int ApplicantId { get; set; }

        public string Content { get; set; }
    }
}
