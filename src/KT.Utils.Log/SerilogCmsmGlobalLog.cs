using Microsoft.Extensions.Configuration;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;
using System.Net.Http.Headers;
using System.Text;

namespace KT.Utils.Log;

public class SerilogCmsmGlobalLog : ILogEventSink, IDisposable
{
    private readonly CmsmGlobalLogConfig _config;

    private readonly HttpClient _httpClient;

    internal SerilogCmsmGlobalLog(CmsmGlobalLogConfig config)
    {
        _config = config;

        if (!string.IsNullOrWhiteSpace(_config.ApiUrl) && !string.IsNullOrWhiteSpace(_config.ApiKey))
        {
            _httpClient = new HttpClient { Timeout = TimeSpan.FromMinutes(5) };
            _httpClient.DefaultRequestHeaders.Add("User-Agent", $"KT-{nameof(SerilogCmsmGlobalLog)}");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _config.ApiKey);
        }
    }

    public void Emit(LogEvent logEvent)
    {
        if (logEvent == null || _httpClient == null || _disposed)
        {
            return;
        }

        _ = Task.Factory.StartNew(async () => await AddLogAsync(logEvent));
    }

    private async Task AddLogAsync(LogEvent logEvent)
    {
        try
        {
            var log = new
            {
                MachineName = CommonHelper.MachineName(),
                MachineIp = CommonHelper.MachineIpByDns(),
                //Logger = loggingEvent.LoggerName,
                LogDateUtc = logEvent.Timestamp.ToUniversalTime(),
                //Identity = loggingEvent.Identity,
                Level = LevelName(logEvent.Level),
                Message = logEvent.RenderMessage(),
                Exception = logEvent.Exception?.ToString(),
                Metadata = GetMetadata(logEvent)
            };

            _ = await _httpClient.PostAsync(_config.ApiUrl, new StringContent(new { Logs = new[] { log } }.AsJson(), Encoding.UTF8, "application/json"));
        }
        catch { }
    }

    // map to level of log4net
    private string LevelName(LogEventLevel level) => level switch
    {
        LogEventLevel.Information => "Info",
        LogEventLevel.Warning => "Warn",
        _ => level.ToString(),
    };

    private Dictionary<string, string> GetMetadata(LogEvent logEvent)
    {
        var metadata = new Dictionary<string, string> { };

        if (_config.Metadata?.Count > 0)
        {
            foreach (var item in _config.Metadata)
            {
                metadata[item.Key] = item.Value;
            }
        }

        if (logEvent?.Properties?.Count > 0)
        {
            try
            {
                foreach (var item in logEvent.Properties)
                {
                    metadata[item.Key] = item.Value.ToString();
                }
            }
            catch { }
        }

        return metadata.Count > 0 ? metadata : null;
    }

    #region Disposable

    private bool _disposed;

    public void Dispose()
    {
        if (!_disposed)
        {
            _httpClient?.Dispose();
            _disposed = true;
        }
    }

    #endregion
}

internal class CmsmGlobalLogConfig
{
    public string ApiUrl { get; set; }

    public string ApiKey { get; set; }

    public Dictionary<string, string> Metadata { get; set; }
}

public static class SerilogCmsmGlobalLogExtensions
{
    public static (bool Success, LoggerConfiguration LogConfig) CmsmGlobalLog(this LoggerSinkConfiguration loggerConfiguration, IConfiguration configuration)
    {
        try
        {
            var config = new CmsmGlobalLogConfig();
            configuration.GetSection("Logging:Appenders:CmsmGlobalLog").Bind(config);

            if (string.IsNullOrWhiteSpace(config.ApiUrl) || string.IsNullOrWhiteSpace(config.ApiKey))
            {
                return (false, null);
            }

            return (true, loggerConfiguration.Sink(new SerilogCmsmGlobalLog(config)));
        }
        catch
        {
            return (false, null);
        }
    }
}
