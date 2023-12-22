using KT.Common.Json;
using Newtonsoft.Json.Serialization;

namespace KT.Common;

public static class JsonHelper
{
    public static readonly JsonSerializerSettings DefaultSettings;

    static JsonHelper()
    {
        DefaultSettings = GetDefaultSettings();
        DefaultSettings.TypeNameHandling = TypeNameHandling.Auto;
    }

    public static JsonSerializerSettings GetDefaultSettings() => new()
    {
        // Error = (a, e) => e.ErrorContext.Handled = true,
        Formatting = Formatting.None,
        NullValueHandling = NullValueHandling.Ignore,
        Converters = { new ObjectIdJsonConverter() }, // , new ValueTupleJsonConverter()
        ContractResolver = new DefaultContractResolver(),  // CamelCasePropertyNamesContractResolver
    };

    public static void SetDefault(JsonSerializerSettings target)
    {
        target.Formatting = DefaultSettings.Formatting;
        target.NullValueHandling = DefaultSettings.NullValueHandling;
        target.ContractResolver = DefaultSettings.ContractResolver;
        target.TypeNameHandling = DefaultSettings.TypeNameHandling;
        foreach (var converter in DefaultSettings.Converters)
        {
            target.Converters.Add(converter);
        }
    }

    public static string AsJson(this object source, JsonSerializerSettings settings = null)
        => source == null ? null : JsonConvert.SerializeObject(source, settings ?? DefaultSettings);

    public static T AsObject<T>(this string json, JsonSerializerSettings settings = null)
        => string.IsNullOrWhiteSpace(json) ? default : JsonConvert.DeserializeObject<T>(json, settings ?? DefaultSettings);

    public static object AsObject(this string json, Type type, JsonSerializerSettings settings = null)
       => string.IsNullOrWhiteSpace(json) ? default : JsonConvert.DeserializeObject(json, type, settings ?? DefaultSettings);
}
