using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace KT.Common;

public static partial class StringHelper
{
    public static bool IsNotEmpty(this string source) => !string.IsNullOrWhiteSpace(source);

    public static string FormatX(this string source, object obj)
    {
        //more: http://james.newtonking.com/archive/2008/03/29/formatwith-2-0-string-formatting-with-named-variables
        MatchCollection keys;
        if (obj == null || (keys = Regex.Matches(source, @"\{(?<KeyName>.+?)\}")).Count == 0)
            return source;

        var tmp = source;
        var objType = obj.GetType();

        foreach (Match key in keys)
        {
            var keyName = key.Groups["KeyName"].Value;
            var prop = objType.GetProperty(keyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.IgnoreCase);

            if (prop == null)
            {
                continue;
            }

            var propValue = prop.GetValue(obj).ToStr();
            tmp = tmp.Replace(key.Value, propValue);
        }

        return tmp;
    }

    public static bool EqualsX(this string source, string value)
        => (source == null && value == null) || (source != null && value != null && source.Equals(value, StringComparison.OrdinalIgnoreCase));

    public static bool ContainsX(this string source, string value)
        => source != null && value != null && source.Contains(value, StringComparison.OrdinalIgnoreCase);

    public static bool StartsWithX(this string source, string value)
      => source != null && value != null && source.StartsWith(value, StringComparison.OrdinalIgnoreCase);

    public static bool EndsWithX(this string source, string value)
        => source != null && value != null && source.EndsWith(value, StringComparison.OrdinalIgnoreCase);

    public static string Left(this string source, int left)
    {
        if (left <= 0)
        {
            return string.Empty;
        }

        source ??= string.Empty;

        return source.Length <= left ? source : source[..left];
    }

    public static string Right(this string source, int right)
    {
        if (right <= 0)
        {
            return string.Empty;
        }

        source ??= string.Empty;

        return source.Length <= right ? source : source.Substring(source.Length - right, right);
    }

    public static string Middle(this string source, int startIndex, int length)
    {
        source ??= string.Empty;

        return startIndex >= 0 && source.Length > startIndex
            ? source[startIndex..].Left(length)
            : string.Empty;
    }

    public static string FriendlyCase(this string value, string removeText = "")
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return "";
        }

        var friendlyCase = Regex.Replace(value, "(?!^)([A-Z])", " $1");

        return string.IsNullOrWhiteSpace(removeText) ? friendlyCase : friendlyCase.Replace(removeText, "");
    }

    public static string FormatPhoneNumber(this string source, string pattern = @"(\d{3})(\d{3})(\d{4})", string display = "$1-$2-$3")
       => Regex.Replace(ConvertHelper.ToPhoneNumber(source), pattern, display);

    public static string FormatSsn(this string source, string pattern = @"(\d{3})(\d{2})(\d{4})", string display = "$1-$2-$3")
       => Regex.Replace(ConvertHelper.ToSsnNumber(source), pattern, display);

    public static string ToDomainName(this string source)
    {
        var domain = source.ToStr().ToLower();

        if (domain.StartsWith("http://")) domain = domain[7..];
        if (domain.StartsWith("https://")) domain = domain[8..];
        if (domain.StartsWith("www.")) domain = domain[4..];

        var indexSlash = domain.IndexOf("/");
        if (indexSlash >= 0)
        {
            domain = domain[..indexSlash];
        }

        return domain;
    }
    public static bool IsEmail(this string email, string pattern = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
        => !string.IsNullOrWhiteSpace(email) && Regex.IsMatch(email, pattern);

    public static string GenerateSlug(this string source, int? length = null)
    {
        var bytes = Encoding.UTF8.GetBytes(source);
        source = Encoding.ASCII.GetString(bytes).ToLower();

        // invalid chars           
        source = Regex.Replace(source, @"[^a-z0-9\s-]", "");

        // convert multiple spaces into one space   
        source = Regex.Replace(source, @"\s+", " ").Trim();

        if (length > 0)
        {
            source = source[..(source.Length <= length.Value ? source.Length : length.Value)].Trim();
        }

        source = Regex.Replace(source.Trim(), @"\s", "-"); // hyphens   

        return source;
    }

    public static string FormatMoney(this decimal source)
        => source >= 0 ? source.ToString("C2") : $"-{-source:C2}";
}
