using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public class TriggerValidation
    {
        public List<string> RequireFileProperties { get; set; } = new List<string>();
    }
}
