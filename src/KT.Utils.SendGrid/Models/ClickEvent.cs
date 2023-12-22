using KT.Utils.SendGrid.Converters;
using Newtonsoft.Json;
using System;

namespace KT.Utils.SendGrid.Models
{
    public class ClickEvent : OpenEvent
    {
        [JsonConverter(typeof(UriConverter))]
        public Uri Url { get; set; }

        public override object ToMetadata(bool full) => full ? this : new { Url = Url?.ToString() };
    }
}
