using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public class BusinessFileDynamicValue
    {
        public List<ScriptValue> ScriptValues { get; set; } = new List<ScriptValue>();

        [Serializable]
        public class ScriptValue : KTWrapMongoEntity
        {
            public ObjectId FieldId { get; set; }

            public string Value { get; set; }
        }
    }
}
