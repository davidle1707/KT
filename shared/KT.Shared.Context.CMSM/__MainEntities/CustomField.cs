using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable, KTWrapMongoCollectionName(typeof(CustomField))]
    [BsonDiscriminator(Required = true)]
    public abstract partial class CustomField : KTWrapMongoEntity
    {
        public int MappingType { get; set; }

        public string FieldCaption { get; set; }

        public int FieldIndex { get; set; }

        public bool IsFieldRequired { get; set; }

        public string CgiPostParamName { get; set; }

        public string DocumentParamName { get; set; }

        public int DataType { get; set; }

        public int ControlType { get; set; }

        [BsonIgnoreIfNull]
        public string ControlLookupType { get; set; }

        [BsonIgnoreIfNull]
        public int? LookupAppSettingType { get; set; }

        [BsonIgnoreIfNull]
        public string HintDesc { get; set; }

        [BsonIgnoreIfNull]
        public string DisplayTextIfEmpty { get; set; }
    }

    [BsonKnownTypes(typeof(Fixed), typeof(Dynamic))]
    public abstract partial class CustomField
    {
        [Serializable, BsonDiscriminator(nameof(Fixed), Required = true)]
        public class Fixed : CustomField
        {
            public int MappingSection { get; set; }

            public string ObjectEntity { get; set; }

            public string MappingPropertyName { get; set; }

            public string MappingFunctionName { get; set; }
        }

        [Serializable, BsonDiscriminator(nameof(Dynamic), Required = true)]
        public class Dynamic : CustomField
        {
            public ObjectId OrganizationId { get; set; }
        }
    }
}
