using System;
using System.Collections.Generic;
using System.Text;

namespace KT.Shared.Context.CMSM.Utils
{
    public class LendingQbFieldAttribute : Attribute
    {
        public string Section { get; set; }

        public int Type { get; set; }

        public string Name { get; set; }

        public string PropName { get; set; }

        public int? Convertion { get; set; }

        public bool IsSubmit { get; set; }

        public bool IsLoad { get; set; }

        public int? LookupAppSettingType { get; set; }

        public string Description { get; set; }

        public LendingQbFieldAttribute(string name, string section = "Loan")
        {
            Name = name;
            Section = section;
        }
    }

    public class LendingQbClassAttribute : Attribute
    {
        public string Description { get; set; }
    }
}
