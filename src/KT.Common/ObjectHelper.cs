using System.Linq.Expressions;
using System.Reflection;

namespace KT.Common;

public static class ObjectHelper
{
    public static string MemberFullName<T>(this Expression<Func<T, object>> expression, string separator = ".")
        => string.Join(separator, expression.MemberNames());

    public static List<string> MemberNames<T>(this Expression<Func<T, object>> expression)
        => MemberNames<T, object>(expression);

    public static string MemberFullName<T, TField>(this Expression<Func<T, TField>> expression, string separator = ".")
        => string.Join(separator, expression.MemberNames());

    public static List<string> MemberNames<T, TField>(this Expression<Func<T, TField>> expression)
    {
        var props = Members(expression);
        return props.Select(a => a.Name).ToList();
    }

    public static List<MemberInfo> Members<T, TField>(this Expression<Func<T, TField>> expression)
    {
        var props = new Stack<MemberInfo>();
        var me = expression.Body.NodeType switch
        {
            ExpressionType.Convert or ExpressionType.ConvertChecked => ((expression.Body is UnaryExpression ue) ? ue.Operand : null) as MemberExpression,
            _ => expression.Body as MemberExpression,
        };

        while (me != null)
        {
            props.Push(me.Member);
            me = me.Expression as MemberExpression;
        }

        return props.ToList();
    }

    public static MemberInfo MemberInfo(this Expression method)
    {
        if (method is not LambdaExpression lambda)
        {
            return null;
        }

        var me = lambda.Body.NodeType switch
        {
            ExpressionType.Convert or ExpressionType.ConvertChecked => ((lambda.Body is UnaryExpression ue) ? ue.Operand : null) as MemberExpression,
            _ => lambda.Body as MemberExpression,
        };

        return me?.Member;
    }

    /// <summary>
    /// By Json
    /// </summary>
    public static T Clone<T>(this T source)
    {
        if (source == null)
        {
            return default;
        }

        var json = JsonHelper.AsJson(source);
        if (string.IsNullOrWhiteSpace(json))
        {
            return default;
        }

        return JsonHelper.AsObject<T>(json);
    }

    /// <summary>
    /// Currently only apply for simple object (properties are not list, array, dictionary)
    /// </summary>
    public static Dictionary<string, object> ToDictionary(this object source, string prefix = "")
    {
        var dictionary = new Dictionary<string, object>();
        if (source == null)
        {
            return dictionary;
        }

        foreach (var prop in source.GetType().GetProperties())
        {
            var propValue = prop.GetValue(source);
            FetchValues(prop, propValue, prefix);
        }

        return dictionary;

        void FetchValues(PropertyInfo objProp, object objValue, string prefixKey)
        {
            if (objValue == null)
            {
                return;
            }

            var key = !string.IsNullOrEmpty(prefixKey) ? $"{prefixKey}.{objProp.Name}" : objProp.Name;

            if (objProp.PropertyType.IsValueType || objProp.PropertyType.FullName == "System.String")
            {
                dictionary.Add(key, objValue);
            }
            else if (objProp.PropertyType.IsClass)
            {
                foreach (var subProp in objProp.PropertyType.GetProperties())
                {
                    var subObj = subProp.GetValue(objValue);
                    FetchValues(subProp, subObj, key);
                }
            }
        }
    }

    public static bool IsNullable(this Type source) => Nullable.GetUnderlyingType(source) != null;

    public static bool IsValueType(this Type type)
    {
        if (type.IsNullable())
        {
            type = Nullable.GetUnderlyingType(type);
        }

        return type.IsPrimitive || type.IsEnum
            || type == typeof(DateTime)
            || type == typeof(TimeSpan)
            || type == typeof(decimal)
            || type == typeof(double)
            || type == typeof(float)
            || type == typeof(long)
            || type == typeof(int)
            || type == typeof(short)
            || type == typeof(string)
            || type == typeof(char)
            || type == typeof(bool)
            || type == typeof(Guid)
            || type == typeof(ObjectId);
    }

    public static bool BoolPropsAnyTrue(this object source)
    {
        if (source == null)
        {
            return false;
        }

        var typeBool = typeof(bool);

        foreach (var prop in source.GetType().GetProperties())
        {
            if (prop.PropertyType.SafeType() == typeBool)
            {
                var value = prop.GetValue(source);
                if (value is bool valBool && valBool)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static Type SafeType(this Type type) => Nullable.GetUnderlyingType(type) ?? type;

    public static bool IsDiff(this object source, object compare)
    {
        if (source == null)
        {
            return compare != null;
        }
        if (compare == null)
        {
            return source != null;
        }

        //var jSource = JsonConvert.SerializeObject(source);
        //var jCompare = JsonConvert.SerializeObject(compare);
        //return jSource != jCompare;

        return !source.Equals(compare);
    }

    public static bool In<T>(this T source, params T[] list) where T : struct => list.Any(a => a.Equals(source));

    public static string GetTypeName(this Type type, bool shortName = false)
    {
        var name = type.Name;
        if (type.IsGenericType)
        {
            var nullableType = Nullable.GetUnderlyingType(type);
            if (nullableType == null)
            {
                return name;
            }

            name = nullableType.Name;
        }

        if (shortName)
        {
            name = name switch
            {
                "String" => "string",
                "Boolean" => "bool",
                "Int16" => "short",
                "Int32" => "int",
                "Int64" => "long",
                "Single" => "float",
                "Double" => "double",
                "Decimal" => "decimal",
                _ => name
            };
        }

        return $"{name}{(type.IsGenericType ? "?" : "")}";
    }
}
