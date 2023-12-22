using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace KT.Utils.SendGrid.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EventType
    {
        Processed,
        Deferred,
        Delivered,
        Open,
        Click,
        Bounce,
        Dropped,
        SpamReport,
        Unsubscribe,
        [EnumMember(Value = "group_unsubscribe")]
        GroupUnsubscribe,
        [EnumMember(Value = "group_resubscribe")]
        GroupResubscribe
    }
}
