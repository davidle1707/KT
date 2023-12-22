using System.Text.RegularExpressions;

namespace KT.Common;

public static class ConvertHelper
{
    #region Converter

    private static Dictionary<string, Func<object, object>> _converters;

    /// <summary>
    /// string, bool, boolean, short, int16, int, int32, long, int64, float, single, double, decimal, datetime, guid, objectid
    /// </summary>
    public static Dictionary<string, Func<object, object>> Converters => _converters ??= new()
    {
        ["string"] = val => val.ToStr(),

        ["bool"] = val => val.ToBool(),
        ["bool?"] = val => val.ToBoolNull(),

        ["boolean"] = val => val.ToBool(),
        ["boolean?"] = val => val.ToBoolNull(),

        ["short"] = val => val.ToShort(),
        ["short?"] = val => val.ToShortNull(),

        ["int16"] = val => val.ToShort(),
        ["int16?"] = val => val.ToShortNull(),

        ["int"] = val => val.ToInt(),
        ["int?"] = val => val.ToIntNull(),

        ["int32"] = val => val.ToInt(),
        ["int32?"] = val => val.ToIntNull(),

        ["long"] = val => val.ToLong(),
        ["long?"] = val => val.ToLongNull(),

        ["int64"] = val => val.ToLong(),
        ["int64?"] = val => val.ToLongNull(),

        ["float"] = val => val.ToFloat(),
        ["float?"] = val => val.ToFloatNull(),

        ["single"] = val => val.ToFloat(),
        ["single?"] = val => val.ToFloatNull(),

        ["double"] = val => val.ToDouble(),
        ["double?"] = val => val.ToDoubleNull(),

        ["decimal"] = val => val.ToDecimal(),
        ["decimal?"] = val => val.ToDecimalNull(),

        ["datetime"] = val => val.ToDateTime(),
        ["datetime?"] = val => val.ToDateTimeNull(),

        ["guid"] = val => val.ToGuid(),
        ["guid?"] = val => val.ToGuidNull(),

        ["objectid"] = val => val.ToObjectId(),
        ["objectid?"] = val => val.ToObjectIdNull(),
    };

    public static Func<object, object> Converter(this Type valueType)
        => Converter(valueType.GetTypeName());

    /// <summary>
    /// string, bool, short, int16, int, int32, long, int64, float, single, double, decimal, datetime, guid, objectid
    /// </summary>
    public static Func<object, object> Converter(this string valueTypeName)
        => Converters.TryGetValue(valueTypeName.ToLower(), out var converter) ? converter : null;

    #endregion

    #region string

    public static bool TryToStr(this object source, out string val)
    {
        val = null;
        if (source == null || source.Equals(DBNull.Value))
        {
            return false;
        }

        val = source.ToString().Trim();
        return true;
    }

    public static string ToStr(this object source, bool trim = true, string defValue = "")
    {
        if (source == null || source == DBNull.Value)
        {
            return defValue;
        }

        return trim ? source.ToString().Trim() : source.ToString();
    }

    public static string ToNumeric(this object source, string defValue = "")
        => source == null ? defValue : Regex.Replace(source.ToString(), "[^0-9]", "").Trim();

    #endregion

    #region bool

    private static readonly string[] _boolValues = { "yes", "y", "true", "true,false", "on" };

    public static bool TryToBool(this object source, out bool outVal)
    {
        var val = source.ToBoolNull();
        outVal = val ?? false;

        return val != null;
    }

    public static bool ToBool(this object source, bool defVal = default) => source.ToBoolNull() ?? defVal;

    public static bool? ToBoolNull(this object source)
    {
        if (source == null) return null;

        var strVal = source.ToStr().ToLower();
        if (string.IsNullOrWhiteSpace(strVal)) return null;

        return _boolValues.Contains(strVal);
    }

    #endregion

    #region short

    public static bool TryToShort(this object source, out short val)
    {
        var toVal = source.ToShortNull();
        val = toVal ?? 0;

        return toVal != null;
    }

    public static short ToShort(this object source, short defVal = default) => source.ToShortNull() ?? defVal;

    public static short? ToShortNull(this object source) => ProcessToNumberNull<short>(source, short.TryParse);

    #endregion

    #region int

    public static bool TryToInit(this object source, out int val)
    {
        var toVal = source.ToIntNull();
        val = toVal ?? 0;

        return toVal != null;
    }

    public static int ToInt(this object source, int defVal = default) => source.ToIntNull() ?? defVal;

    public static int? ToIntNull(this object source) => ProcessToNumberNull<int>(source, int.TryParse);

    #endregion

    #region long

    public static bool TryToLong(this object source, out long val)
    {
        var toVal = source.ToLongNull();
        val = toVal ?? 0;

        return toVal != null;
    }

    public static long ToLong(this object source, long defVal = default) => source.ToLongNull() ?? defVal;

    public static long? ToLongNull(this object source) => ProcessToNumberNull<long>(source, long.TryParse);

    #endregion

    #region float

    public static bool TryToFloat(this object source, out float val)
    {
        var toVal = source.ToFloatNull();
        val = toVal ?? 0;

        return toVal != null;
    }

    public static float ToFloat(this object source, float defVal = default) => source.ToFloatNull() ?? defVal;

    public static float? ToFloatNull(this object source) => ProcessToNumberNull<float>(source, float.TryParse);

    #endregion

    #region double

    public static bool TryToDouble(this object source, out double val)
    {
        var toVal = source.ToDoubleNull();
        val = toVal ?? 0;

        return toVal != null;
    }

    public static double ToDouble(this object source, double defVal = default) => source.ToDoubleNull() ?? defVal;

    public static double? ToDoubleNull(this object source) => ProcessToNumberNull<double>(source, double.TryParse);

    #endregion

    #region decimal

    public static bool TryToDecimal(this object source, out decimal val, int? decimalPoints = null, bool noRound = false)
    {
        var toVal = source.ToDecimalNull(decimalPoints, noRound);
        val = toVal ?? 0;

        return toVal != null;
    }

    public static decimal ToDecimal(this object source, decimal defVal = default, int? decimalPoints = null, bool noRound = false) => source.ToDecimalNull(decimalPoints, noRound) ?? defVal;

    /// <summary>
    /// noRound only apply if decimalPoints is not null
    /// </summary>
    public static decimal? ToDecimalNull(this object source, int? decimalPoints = null, bool noRound = false)
    {
        var decNum = ProcessToNumberNull<decimal>(source, decimal.TryParse);

        return decNum != null && decimalPoints > 0
            ? noRound ? ToDecimalNoRound(decNum.Value, decimalPoints.Value) : decimal.Round(decNum.Value, decimalPoints.Value)
            : decNum;
    }

    /// <summary>
    /// ex: 1.2357 with points 3 => 1.235
    /// </summary>
    public static decimal ToDecimalNoRound(this decimal source, int decimalPoints = 2)
    {
        var pow10 = (decimal)Math.Pow(10, decimalPoints);
        return decimal.Truncate(source * pow10) / pow10; // ex: 1.2357 with points 3 => 1.235
    }

    #endregion

    #region DateTime

    public static DateTime ToDateTime(this object source, DateTime defValue = default)
    {
        if (source is DateTime isVal)
        {
            return isVal;
        }

        var str = source.ToStr();
        if (string.IsNullOrWhiteSpace(str))
        {
            return defValue;
        }

        return DateTime.TryParse(str, out var outVal) ? outVal : defValue;
    }

    public static DateTime? ToDateTimeNull(this object source, DateTime? defValue = null)
    {
        if (source is DateTime isVal)
        {
            return isVal;
        }

        var str = source.ToStr();
        if (string.IsNullOrWhiteSpace(str))
        {
            return defValue;
        }

        return DateTime.TryParse(str, out var outVal) ? outVal : (DateTime?)null;
    }

    #endregion

    #region ObjectId

    public static bool TryToObjectId(this object source, out ObjectId outValue)
    {
        var val = source.ToObjectIdNull();
        outValue = val ?? ObjectId.Empty;

        return val != null;
    }

    public static ObjectId ToObjectId(this object source) => source.ToObjectIdNull() ?? ObjectId.Empty;

    public static ObjectId? ToObjectIdNull(this object source)
    {
        if (source == null) return null;

        var strVal = source.ToString();
        if (string.IsNullOrWhiteSpace(strVal)) return null;

        try
        {
            return new ObjectId(strVal);
        }
        catch { return null; }
    }

    #endregion

    #region Guid

    public static bool TryToGuid(this object source, out Guid outVal)
    {
        var val = source.ToGuidNull();
        outVal = val ?? Guid.Empty;

        return val != null;
    }

    public static Guid ToGuid(this object source) => source.ToGuidNull() ?? Guid.Empty;

    public static Guid? ToGuidNull(this object source)
    {
        if (source == null) return null;

        var strVal = source.ToStr();
        if (string.IsNullOrWhiteSpace(strVal)) return null;

        try
        {
            return new Guid(strVal);
        }
        catch { return null; }
    }

    #endregion

    #region Phone && Ssn

    public static string ToPhoneNumber(this object source, int length = 10, string removeArea = "1")
    {
        var phone = Regex.Replace(source.ToStr(), "[^0-9]", "");

        if (!string.IsNullOrWhiteSpace(removeArea) && phone.Length > 10 && (phone.StartsWith(removeArea) || phone.StartsWith($"+{removeArea}")))
        {
            phone = phone[1..];
        }

        return phone.Left(length).Trim();
    }

    public static string ToSsnNumber(this object source, int length = 9)
    {
        var ssn = Regex.Replace(source.ToStr(), "[^0-9]", "");
        return ssn.Left(length).Trim();
    }

    #endregion

    private delegate bool NumberTryParse<T>(string s, out T result) where T : struct;

    private static T? ProcessToNumberNull<T>(this object source, NumberTryParse<T> tryParse) where T : struct
    {
        if (source == null) return null;
        if (source is T okVal) return okVal;

        var strNumber = source.ToStrNumber();
        if (string.IsNullOrWhiteSpace(strNumber)) return null;

        return !tryParse(strNumber, out var result) ? (T?)null : result;
    }

    private static string ToStrNumber(this object source, string symbolGroup = ",")
      => source == null ? "" : source.ToStr().Replace(symbolGroup, "");
}