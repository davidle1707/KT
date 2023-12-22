using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public class TriggerLendingQB
    {
        public string Operator { get; set; } = "And";

        public List<Condition> Conditions { get; set; } = new List<Condition>();

        public string Expression { get; set; }

        [Serializable]
        public class Condition
        {
            public int Section { get; set; }

            public string Element { get; set; }

            public string Operator { get; set; }

            public string Value { get; set; }
        }
    }

    [Serializable]
    public class TriggerBytePro
    {
        public int Event { get; set; }

        public string Name { get; set; }

        public string[] Tags { get; set; }
    }
}
