using Newtonsoft.Json;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(SalesNexusField))]
    public partial class SalesNexusField : KTWrapMongoEntity
    {
        [JsonProperty("field-id")]
        public string FieldId { get; set; }

        [JsonProperty("table-name")]
        public string TableName { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("is-drop-down")]
        public string IsDropDown { get; set; }

        [JsonProperty("is-multiselect")]
        public string IsMultiselect { get; set; }

        [JsonProperty("values")]
        public LookupItem[] LookupItems { get; set; }

        [JsonProperty("is-read-only")]
        public string IsReadOnly { get; set; }

        [JsonProperty("is-primary")]
        public string IsPrimary { get; set; }

        [JsonProperty("unique-id")]
        public string UniqueId { get; set; }

        [JsonProperty("is-primary-key")]
        public string IsPrimaryKey { get; set; }
    }

    public partial class SalesNexusField
    {
        [Serializable]
        public class LookupItem
        {
            [JsonProperty("p-index")]
            public string PIndex { get; set; }

            [JsonProperty("unique-id")]
            public string UniqueId { get; set; }

            [JsonProperty("value")]
            public string Value { get; set; }

            [JsonProperty("popup-unique-id")]
            public string PopupUniqueId { get; set; }
        }
    }
}
