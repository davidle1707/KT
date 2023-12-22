using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(EligibilityTestSet))]
    public partial class EligibilityTestSet : KTWrapMongoEntity, IIdName
    {
        public int Type { get; set; }

        public string Name { get; set; }

        public List<string> CaseFieldNames { get; set; } = new List<string>();

        public List<TestCase> Cases { get; set; } = new List<TestCase>();

        public List<TestField> DefFields { get; set; } = new List<TestField>();
    }

    public partial class EligibilityTestSet
    {
        [Serializable]
        public class TestCase : KTWrapMongoEntityId
        {
            public string Expect { get; set; }

            public List<TestField> Fields { get; set; } = new List<TestField>();

            public string Description { get; set; }
        }

        [Serializable]
        public class TestField
        {
            public string Section { get; set; }

            public string Name { get; set; }

            public string Value { get; set; }
        }
    }

}
