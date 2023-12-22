using Microsoft.Extensions.Configuration;

namespace KT.Utils.AppSetting;

public class AppSettingImp : IAppSetting
{
    private readonly IConfiguration _configuration;

    public AppSettingImp(IConfiguration configuration) => _configuration = configuration;

    public string this[string key] => _configuration[key];

    public string AsStr(string key) => this[key];

    public int AsInt(string key, int def = 0) => int.TryParse(this[key], out var outInt) ? outInt : def;

    public bool AsBool(string key, bool def = false) => bool.TryParse(this[key], out var outBool) ? outBool : def;

    public static IConfigurationRoot BuildConfiguration(string contentRootPath, string mode = "dev", Func<IConfigurationBuilder, IConfigurationBuilder> extend = null)
    {
        var builder = new ConfigurationBuilder()
           .SetBasePath(contentRootPath)
           .AddEnvironmentVariables();

        // default configs
        var defPath = mode.Equals("dev", StringComparison.OrdinalIgnoreCase)
            ? string.Join('\\', contentRootPath.Trim().Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries).SkipLast(1)) // use configs folder in root source
            : contentRootPath;

        var configsPath = Path.Combine(defPath, "configs");
        if (Directory.Exists(configsPath))
        {
            foreach (var defFilePath in Directory.GetFiles(configsPath, $"*.{mode}.json").OrderBy(a => a))
            {
                builder = builder.AddJsonFile(defFilePath, true, true);
            }
        }


        // app-setting
        builder = builder.AddJsonFile($"appsettings.{mode}.json", true, true);

        if (extend != null)
        {
            builder = extend(builder);
        }

        return builder.Build();
    }
}