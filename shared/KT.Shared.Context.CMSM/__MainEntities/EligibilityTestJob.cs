using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(EligibilityTestJob))]
    public class EligibilityTestJob : KTWrapMongoEntity
    {
        public string Name { get; set; }

        public int Status { get; set; }

        public ObjectId ProductId { get; set; }

        public ObjectId SetId { get; set; }

        public ObjectId[] CaseIds { get; set; }

        public string NotifyEmails { get; set; }

        public string FromFullDomain { get; set; }

        public ObjectId? RunOrgId { get; set; }

        public string OutputExtension { get; set; }
    }
}
