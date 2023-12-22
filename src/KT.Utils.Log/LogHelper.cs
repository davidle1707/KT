using Microsoft.Extensions.Configuration;
using Serilog.Events;
using Serilog.Sinks.Udp.TextFormatters;
using System.Net.Sockets;

namespace KT.Utils.Log;

public static class LogHelper
{
    public static void RegisterSerilog(IConfiguration configuration, Func<LoggerConfiguration, LoggerConfiguration> beforeCreate = null)
        => Serilog.Log.Logger = GetSerilog(configuration, beforeCreate);

    public static ILogger GetSerilog(IConfiguration configuration, Func<LoggerConfiguration, LoggerConfiguration> beforeCreate = null)
    {
        var config = new LoggerConfiguration().Enrich.FromLogContext()
           .WriteTo.Async(configure =>
           {
               // rolling-file
               if (bool.TryParse(configuration["Logging:Appenders:RollingFile:Enable"], out var enableRollingFile) && enableRollingFile)
               {
                   configure.RollingFile(
                       pathFormat: configuration["Logging:Appenders:RollingFile:PathFormat"],
                       outputTemplate: configuration["Logging:Appenders:RollingFile:OutputTemplate"],
                       retainedFileCountLimit: int.TryParse(configuration["Logging:Appenders:RollingFile:RetainedDays"], out var retainedDays) ? retainedDays : 31,
                       buffered: false
                   );
               }

               // log4net
               if (bool.TryParse(configuration["Logging:Appenders:Log4Net:Enable"], out var enableLog4Net) && enableLog4Net)
               {
                   configure.Udp(
                       remoteAddress: configuration["Logging:Appenders:Log4Net:RemoteAddress"],
                       remotePort: int.TryParse(configuration["Logging:Appenders:Log4Net:RemotePort"], out var remortPort) ? remortPort : 8080,
                       family: AddressFamily.InterNetwork,
                       formatter: new Log4netTextFormatter()
                   );
               }

               // cmsm-global-log
               if (bool.TryParse(configuration["Logging:Appenders:CmsmGlobalLog:Enable"], out var enableCmsmGlobalLog) && enableCmsmGlobalLog)
               {
                   configure.CmsmGlobalLog(configuration);
               }
           });

        if (beforeCreate != null)
        {
            config = beforeCreate(config);
        }
        else // default
        {
            config = config
               .MinimumLevel.Debug()
               .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
               .MinimumLevel.Override("System", LogEventLevel.Warning);
        }

        return config.CreateLogger();
    }

    public static void ReleaseSerilog()
    {
        Serilog.Log.CloseAndFlush();
    }
}
