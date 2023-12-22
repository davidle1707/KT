using Newtonsoft.Json.Linq;

namespace KT.Common.Json;

public class ObjectIdJsonConverter : JsonConverter
{
    private static Lazy<ObjectIdJsonConverter> _instance = new(() => new ObjectIdJsonConverter());

    public static ObjectIdJsonConverter Instance => _instance.Value;

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(ObjectId) || objectType == typeof(ObjectId?);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var value = JToken.Load(reader).ToObject<string>();

        if (value == null)
        {
            return objectType == typeof(ObjectId) ? ObjectId.Empty : (ObjectId?)null;
        }

        return objectType == typeof(ObjectId) ? value.ToObjectId() : value.ToObjectIdNull();
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value?.ToString());
    }
}