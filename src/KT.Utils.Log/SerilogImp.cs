namespace KT.Utils.Log;

public class SerilogImp : ILog
{
    private readonly KTContext _context;

    private static ILogger _logger => Serilog.Log.Logger;

    public SerilogImp(KTContext context)
    {
        _context = context;
    }

    public void Debug(string message)
    {
        _logger.Debug(OptimizeMessage(message));
    }

    public void Error(Exception ex)
    {
        Error(ex, ex.Message);
    }

    public void Error(string message)
    {
        _logger.Error(OptimizeMessage(message));
    }

    public void Error(Exception ex, string message)
    {
        if (ex == null)
        {
            Error(message);
        }
        else
        {
            _logger.Error(ex, OptimizeMessage(message));
        }
    }

    public void Info(string message)
    {
        _logger.Information(OptimizeMessage(message));
    }

    public void Info(Exception ex, string message)
    {
        if (ex == null)
        {
            Info(message);
        }
        else
        {
            _logger.Information(ex, OptimizeMessage(message));
        }
    }

    private string OptimizeMessage(string message)
    {
        return message;
    }

    public void Release()
    {
    }
}
