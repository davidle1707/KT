using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace KT.Utils.SendGrid.Models
{
    public class BounceEvent : DroppedEvent
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public BounceEventType BounceType { get; set; }

        public override object ToMetadata(bool full) => full ? this : new { BounceType = BounceType.ToString() };
    }
}
