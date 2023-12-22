namespace KT.Utils.Interfaces;

 public interface ILog
{
    void Debug(string message);

    void Error(Exception ex);

    void Error(string message);

    void Error(Exception ex, string message);

    void Info(string message);

    void Info(Exception ex, string message);
}