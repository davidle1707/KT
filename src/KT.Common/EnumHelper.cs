using System.ComponentModel;
using System.Reflection;

namespace KT.Common;

public static class EnumHelper
{
    public static bool IsDefined<TEnum>(object value) where TEnum : struct
        => Enum.IsDefined(typeof(TEnum), value);

    #region Get

    public static bool TryGetEnum<TEnum>(this object source, out TEnum result) where TEnum : struct
    {
        var value = GetEnumNull<TEnum>(source);
        result = value ?? default;

        return value != null;
    }

    public static TEnum GetEnum<TEnum>(this object source, TEnum defValue = default) where TEnum : struct
       => GetEnumNull<TEnum>(source) ?? defValue;

    public static TEnum? GetEnumNull<TEnum>(this object source) where TEnum : struct
        => source != null && Enum.TryParse<TEnum>(source.ToString(), true, out var outValue) ? outValue : (TEnum?)null;

    public static string GetDescription(this Enum @enum, bool enumNameIfNotFound = true, bool friendlyName = true)
    {
        var attr = @enum.GetAttribute<DescriptionAttribute>();
        if (attr != null)
        {
            return attr.Description;
        }

        return enumNameIfNotFound ? (friendlyName ? @enum.ToString().FriendlyCase() : @enum.ToString()) : string.Empty;
    }

    public static TAttribute GetAttribute<TAttribute>(this Enum @enum)
        where TAttribute : Attribute
    {
        var fieldInfo = @enum.GetType().GetField(@enum.ToString());
        return fieldInfo?.GetCustomAttribute<TAttribute>();
    }

    #endregion

    #region Convert

    public static Dictionary<int, string> ToDictionary<TEnum>(bool useDescription = true, bool friendlyName = true) where TEnum : struct
        => friendlyName ? ToDictionary<TEnum>(a => a.FriendlyCase(), useDescription) : ToDictionary<TEnum>(null, useDescription);

    public static Dictionary<int, string> ToDictionary<TEnum>(Func<string, string> formatName, bool useDescription = true) where TEnum : struct
    {
        var enums = new Dictionary<int, string>();

        var enumType = typeof(TEnum);
        if (enumType.BaseType == typeof(Enum))
        {
            foreach (int value in Enum.GetValues(enumType))
            {
                var name = "";
                var obj = Enum.ToObject(enumType, value);

                if (useDescription)
                {
                    name = ((Enum)obj).GetDescription(friendlyName: false);
                }
                if (string.IsNullOrWhiteSpace(name))
                {
                    name = obj.ToString();
                }

                if (formatName != null) name = formatName(name);

                enums.Add(value, name);
            }
        }

        return enums;
    }

    public static IEnumerable<TEnum> ToEnumerable<TEnum>() where TEnum : struct
    {
        var enumType = typeof(TEnum);
        if (enumType.BaseType == typeof(Enum))
        {
            return Enum.GetValues(enumType).Cast<TEnum>();
        }

        return Enumerable.Empty<TEnum>();
    }

    #endregion
}