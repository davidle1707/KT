namespace KT.Utils.Log;

public static class SerilogGlobal
{
    private static ILogger _logger => Serilog.Log.Logger;

    public static void Debug(string message) => _logger.Debug(message);

    public static void Error(Exception ex) => Error(ex, ex.Message);

    public static void Error(string message) => _logger.Error(message);

    public static void Error(Exception ex, string message) => _logger.Error(ex, message);

    public static void Info(string message) => _logger.Information(message);

    public static void Info(Exception ex, string message) => _logger.Information(ex, message);
}