using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace KT.Common.Json;

 // refer: https://blog.rsuter.com/advanced-newtonsoft-json-dynamically-rename-or-ignore-properties-without-changing-the-serialized-class/
    public class JsonCustomContractResolver : DefaultContractResolver
{
    private readonly Dictionary<string, HashSet<string>> _ignores;
    private readonly Dictionary<string, Dictionary<string, string>> _renames;

    public JsonCustomContractResolver((Type DeclaringType, string[] PropertyNames)[] ignores = null, (Type DeclaringType, (string From, string To)[] NewProperties)[] renames = null)
    {
        _ignores = new Dictionary<string, HashSet<string>>();
        if (ignores != null)
        {
            SetIgnores(ignores);
        }

        _renames = new Dictionary<string, Dictionary<string, string>>();
        if (renames != null)
        {
            SetRenames(renames);
        }
    }

    public void SetIgnores(params (Type DeclaringType, string[] PropertyNames)[] ignores)
    {
        foreach (var item in ignores)
        {
            var key = item.DeclaringType.Name;
            if (!_ignores.ContainsKey(key))
            {
                _ignores[key] = new HashSet<string>();
            }

            foreach (var prop in item.PropertyNames)
            {
                _ignores[key].Add(prop);
            }
        }
    }

    public bool IsIgnored(Type declaringType, string propertyName)
        => _ignores.TryGetValue(declaringType.Name, out var ignores) && ignores.Contains(propertyName);

    public void SetRenames(params (Type DeclaringType, (string From, string To)[] NewProperties)[] renames)
    {
        foreach (var item in renames)
        {
            var key = item.DeclaringType.Name;
            if (!_renames.ContainsKey(key))
            {
                _renames[key] = new Dictionary<string, string>();
            }

            foreach (var prop in item.NewProperties)
            {
                _renames[key][prop.From] = prop.To;
            }
        }
    }

    public bool IsRename(Type declaringType, string propertyName, out string newPropertyName)
    {
        if (!_renames.TryGetValue(declaringType.Name, out var renames) || !renames.TryGetValue(propertyName, out newPropertyName))
        {
            newPropertyName = null;
            return false;
        }

        return true;
    }

    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        var property = base.CreateProperty(member, memberSerialization);

        if (IsIgnored(property.DeclaringType, property.PropertyName))
        {
            property.Ignored = true;
            property.ShouldSerialize = instance => false;
            property.ShouldDeserialize = instance => false;
        }

        if (!property.Ignored && IsRename(property.DeclaringType, property.PropertyName, out var newPropertyName))
        {
            property.PropertyName = newPropertyName;
        }

        return property;
    }
}
