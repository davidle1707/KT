using Newtonsoft.Json.Linq;

namespace KT.Common.Json;

public class ValueTupleJsonConverter : JsonConverter
{
    private readonly bool _throwIfError;

    public ValueTupleJsonConverter(bool throwIfError = true) => _throwIfError = throwIfError;

    public override bool CanConvert(Type objectType) => objectType.Name.Contains("ValueTuple");

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null)
            return null;
        try
        {
            var tupleTypes = objectType.GenericTypeArguments;

            var tupleObject = objectType.GetConstructor(tupleTypes);
            if (tupleObject == null)
            {
                return null;
            }

            var valueItems = new List<object>();
            var jProps = JObject.Load(reader).Children().ToArray();

            for (var i = 0; i < tupleTypes.Length; i++)
            {
                object propValue = null;
                if (i < jProps.Length)
                {
                    try
                    {
                        propValue = jProps[i].ToObject(tupleTypes[i]);
                    }
                    catch { }
                }

                if (propValue == null)
                {
                    propValue = tupleTypes[i].IsValueType ? Activator.CreateInstance(tupleTypes[i]) : null;
                }

                valueItems.Add(propValue);
            }

            return tupleObject.Invoke(valueItems.ToArray());
        }
        catch (Exception)
        {
            if (_throwIfError) throw;
        }

        return null;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }
}
