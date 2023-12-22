using Newtonsoft.Json;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(SalesNexusUser))]
    public class SalesNexusUser : KTWrapMongoEntity
    {
        [JsonProperty("user-name")]
        public string UserName { get; set; }

        [JsonProperty("user-id")]
        public string UserId { get; set; }

        [JsonProperty("security-level")]
        public string SecurityLevel { get; set; }

        [JsonProperty("allow-edit-time-on-activities")]
        public string AllowEditTimeOnActivities { get; set; }

        [JsonProperty("wallow-delete")]
        public string AllowDelete { get; set; }

        [JsonProperty("contact-id")]
        public string ContactId { get; set; }
    }

}
