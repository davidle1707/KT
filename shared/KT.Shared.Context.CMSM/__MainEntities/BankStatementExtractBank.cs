using System;
using System.Collections.Generic;
using System.Text;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(BankStatementExtractBank))]
    public class BankStatementExtractBank : KTWrapMongoEntity
    {
        public int ExtractId { get; set; }

        public string Name { get; set; }

        public string ExtractSlug { get; set; }
    }
}
