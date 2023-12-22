namespace KT.Common;

public static class DateTimeHelper
{
    public const string PacificTimeZoneId = "Pacific Standard Time";

    private static List<(int Value, string ShortName, string StandardName)> _supportTimeZones;

    public static List<(int Value, string ShortName, string StandardName)> SupportTimeZones => _supportTimeZones ??= new List<(int, string, string)>
        {
            (-10, "Hawaiian", "Hawaiian Standard Time"),
            (-9, "Alaskan", "Alaskan Standard Tim"),
            (-8, "Pacific", PacificTimeZoneId),
            (-7, "Mountain", "Mountain Standard Time"),
            (-6, "Central", "Central Standard Time"),
            (-5, "Eastern", "Eastern Standard Time"),
            (7, "Asia", "SE Asia Standard Time"),
        };

    public static string GetTimeZoneStandardName(int value)
    {
        var timeZone = SupportTimeZones.FirstOrDefault(a => a.Value == value);
        if (!string.IsNullOrWhiteSpace(timeZone.StandardName))
        {
            return timeZone.StandardName;
        }

        var timeZoneInfo = TimeZoneInfo.GetSystemTimeZones().FirstOrDefault(c => c.BaseUtcOffset.Hours == value);
        return timeZoneInfo?.Id ?? TimeZoneInfo.Local.StandardName;
    }

    #region TimeZone Value

    public static DateTime NowLocal(int timeZoneValue)
    {
        var timeZoneStandardName = GetTimeZoneStandardName(timeZoneValue);
        return NowLocal(timeZoneStandardName);
    }

    public static DateTime? ToUtcStart(this DateTime? source, int timeZoneValue)
        => source?.ToUtcStart(timeZoneValue);

    public static DateTime? ToUtcEnd(this DateTime? source, int timeZoneValue)
        => source?.ToUtcEnd(timeZoneValue);

    public static DateTime ToUtcStart(this DateTime source, int timeZoneValue)
    {
        var timeZoneStandardName = GetTimeZoneStandardName(timeZoneValue);
        return ToUtcStart(source, timeZoneStandardName);
    }

    public static DateTime ToUtcEnd(this DateTime source, int timeZoneValue)
    {
        var timeZoneStandardName = GetTimeZoneStandardName(timeZoneValue);
        return ToUtcEnd(source, timeZoneStandardName);
    }

    public static DateTime? ToUtc(this DateTime? source, int timeZoneValue, bool checkKind = true)
        => source != null ? ToUtc(source.Value, timeZoneValue, checkKind) : (DateTime?)null;

    public static DateTime? ToLocal(this DateTime? source, int timeZoneValue, bool checkKind = false)
        => source != null ? ToLocal(source.Value, timeZoneValue, checkKind) : (DateTime?)null;

    public static DateTime ToUtc(this DateTime source, int timeZoneValue, bool checkKind = true)
    {
        if (checkKind && source.Kind == DateTimeKind.Utc)
        {
            return source;
        }

        var timeZoneStandardName = GetTimeZoneStandardName(timeZoneValue);
        return ToUtc(source, timeZoneStandardName, checkKind: false);
    }

    public static DateTime ToLocal(this DateTime source, int timeZoneValue, bool checkKind = false)
    {
        if (checkKind && source.Kind == DateTimeKind.Local)
        {
            return source;
        }

        var timeZoneStandardName = GetTimeZoneStandardName(timeZoneValue);
        return ToLocal(source, timeZoneStandardName, checkKind: false);
    }

    #endregion

    #region TimeZone Standard Name

    public static DateTime NowLocal(string timeZoneStandardName)
        => ToLocal(DateTime.UtcNow, timeZoneStandardName);

    public static DateTime? ToUtcStart(this DateTime? source, string timeZoneStandardName)
        => source?.ToUtcStart(timeZoneStandardName);

    public static DateTime? ToUtcEnd(this DateTime? source, string timeZoneStandardName)
        => source?.ToUtcEnd(timeZoneStandardName);

    public static DateTime ToUtcStart(this DateTime source, string timeZoneStandardName)
        => ToUtc(new DateTime(source.Year, source.Month, source.Day, 0, 0, 0, DateTimeKind.Unspecified), timeZoneStandardName, checkKind: false);

    public static DateTime ToUtcEnd(this DateTime source, string timeZoneStandardName)
        => ToUtc(new DateTime(source.Year, source.Month, source.Day, 23, 59, 59, 500, DateTimeKind.Unspecified), timeZoneStandardName, checkKind: false);

    public static DateTime? ByTimeZone(this DateTime? source, string fromTimeZoneStandardName, string toTimeZoneId)
        => source?.ByTimeZone(fromTimeZoneStandardName, toTimeZoneId);

    public static DateTime? ToUtc(this DateTime? source, string timeZoneStandardName, bool checkKind = true)
        => source?.ToUtc(timeZoneStandardName, checkKind);

    public static DateTime? ToLocal(this DateTime? source, string timeZoneStandardName, bool checkKind = false)
        => source?.ToLocal(timeZoneStandardName, checkKind);

    public static DateTime ByTimeZone(this DateTime source, string fromTimeZoneStandardName, string toTimeZoneStandardName)
    {
        if (string.IsNullOrWhiteSpace(fromTimeZoneStandardName) || string.IsNullOrWhiteSpace(toTimeZoneStandardName))
        {
            return source;
        }

        var fromUtc = source.ToUtc(fromTimeZoneStandardName);
        return fromTimeZoneStandardName == toTimeZoneStandardName ? fromUtc : fromUtc.ToLocal(toTimeZoneStandardName);
    }

    public static DateTime ToUtc(this DateTime source, string timeZoneStandardName, bool checkKind = true)
    {
        if (string.IsNullOrWhiteSpace(timeZoneStandardName) || (checkKind && source.Kind == DateTimeKind.Utc))
        {
            return source;
        }

        var unspecified = source.Kind != DateTimeKind.Unspecified ? DateTime.SpecifyKind(source, DateTimeKind.Unspecified) : source;

        return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(unspecified, timeZoneStandardName, TimeZoneInfo.Utc.Id);
    }

    public static DateTime ToLocal(this DateTime source, string timeZoneStandardName, bool checkKind = false)
    {
        if (string.IsNullOrWhiteSpace(timeZoneStandardName) || (checkKind && source.Kind == DateTimeKind.Local))
        {
            return source;
        }

        var utc = source.Kind != DateTimeKind.Utc ? DateTime.SpecifyKind(source, DateTimeKind.Utc) : source;
        var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneStandardName);

        return TimeZoneInfo.ConvertTimeFromUtc(utc, timeZoneInfo);
    }

    #endregion

    public static DateTime FirstDayOfMonth(this DateTime source) => source.Date.AddDays(1 - source.Day);

    public static DateTime LastDayOfMonth(this DateTime source) => source.FirstDayOfMonth().AddMonths(1).AddDays(-1);

    public static int DaysInMonth(this DateTime source) => DateTime.DaysInMonth(source.Year, source.Month);

    public static int Months(this DateTime startDate, DateTime endDate)
    {
        int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
        return Math.Abs(monthsApart);
    }
}
