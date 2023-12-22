using KT.Utils.SendGrid.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace KT.Utils.SendGrid
{
    public class EventConverter : JsonConverter
    {
        private readonly bool _nullIfError;

        public EventConverter(bool nullIfError)
        {
            _nullIfError = nullIfError;
        }

        //private static readonly Dictionary<EventType, Func<string, Event>> eventConverters = new Dictionary<EventType, Func<string, Event>>
        //{
        //    { EventType.Bounce, (json) => JsonConvert.DeserializeObject<BounceEvent>(json) },
        //    { EventType.Click, (json) => JsonConvert.DeserializeObject<ClickEvent>(json) },
        //    { EventType.Deferred, (json) => JsonConvert.DeserializeObject<DeferredEvent>(json) },
        //    { EventType.Delivered, (json) => JsonConvert.DeserializeObject<DeliveredEvent>(json) },
        //    { EventType.Dropped, (json) => JsonConvert.DeserializeObject<DroppedEvent>(json) },
        //    { EventType.GroupResubscribe, (json) => JsonConvert.DeserializeObject<GroupResubscribeEvent>(json) },
        //    { EventType.GroupUnsubscribe, (json) => JsonConvert.DeserializeObject<GroupUnsubscribeEvent>(json) },
        //    { EventType.Open, (json) => JsonConvert.DeserializeObject<OpenEvent>(json) },
        //    { EventType.Processed, (json) => JsonConvert.DeserializeObject<ProcessedEvent>(json) },
        //    { EventType.SpamReport, (json) => JsonConvert.DeserializeObject<SpamReportEvent>(json) },
        //    { EventType.Unsubscribe, (json) => JsonConvert.DeserializeObject<UnsubscribeEvent>(json) },
        //};

        private static readonly Dictionary<EventType, Type> eventTypes = new()
        {
            { EventType.Bounce, typeof(BounceEvent) },
            { EventType.Click,  typeof(ClickEvent) },
            { EventType.Deferred,  typeof(DeferredEvent) },
            { EventType.Delivered,  typeof(DeliveredEvent )},
            { EventType.Dropped, typeof(DroppedEvent) },
            { EventType.GroupResubscribe, typeof(GroupResubscribeEvent)},
            { EventType.GroupUnsubscribe, typeof(GroupUnsubscribeEvent) },
            { EventType.Open, typeof(OpenEvent) },
            { EventType.Processed, typeof(ProcessedEvent)},
            { EventType.SpamReport, typeof(SpamReportEvent)},
            { EventType.Unsubscribe, typeof(UnsubscribeEvent) },
        };

        public override bool CanConvert(Type objectType) => typeof(Event) == objectType;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);

            if (jsonObject.TryGetValue("event", StringComparison.OrdinalIgnoreCase, out JToken eventTypeJsonProperty))
            {
                try
                {

                    var eventType = (EventType)eventTypeJsonProperty.ToObject(typeof(EventType), serializer);

                    if (eventTypes.TryGetValue(eventType, out var type))
                    {
                        return jsonObject.ToObject(type, serializer);
                    }

                    //if (eventConverters.TryGetValue(eventType, out var converter))
                    //{
                    //    return converter(jsonObject.ToString());
                    //}
                }
                catch (Exception ex)
                {
                    if (_nullIfError)
                    {
                        return null;
                    }

                    throw ex;
                }
            }

            if (_nullIfError)
            {
                return null;
            }

            throw new ArgumentOutOfRangeException($"Unknown event type");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
