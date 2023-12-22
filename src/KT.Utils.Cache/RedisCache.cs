using StackExchange.Redis;
using Newtonsoft.Json;

namespace KT.Utils.Cache;

// refer: https://stackexchange.github.io/StackExchange.Redis

/// <summary>
/// Overrite json settings by set RedisCache.JsonSettings
/// </summary>
public class RedisCache : NoCache, ICache
{
    private readonly string _connectionString;
    private readonly string _prefix;
    private readonly int _database;

    public static JsonSerializerSettings JsonSettings;

    public RedisCache(IAppSetting appSetting)
    {
        _connectionString = appSetting["Cache:Redis:ConnectionString"];
        _prefix = appSetting["Cache:Redis:InstanceName"];
        _database = appSetting.AsInt("Cache:Redis:Database");

        Connect();
    }

    public override async Task<bool> AddAsync<T>(string key, T value, TimeSpan? expire = null)
    {
        return await ExecuteAsync(async db =>
        {
            var json = ToJson(value);
            return await db.StringSetAsync(FormatKey(key), json, expire);
        });
    }

    public override async Task<T> GetAsync<T>(string key)
    {
        return await ExecuteAsync(async db =>
        {
            var value = await db.StringGetAsync(FormatKey(key));
            if (!value.HasValue || value.IsNull)
            {
                return default;
            }

            return ToObj<T>(value);
        });
    }

    public override async Task<T> GetOrAddAsync<T>(string key, Func<Task<T>> addAsync, TimeSpan? expire = null)
    {
        return await ExecuteAsync(async db =>
        {
            var formattedKey = FormatKey(key);

            var value = await db.StringGetAsync(formattedKey);
            if (value.HasValue)
            {
                return ToObj<T>(value);
            }

            var obj = await addAsync();
            await db.StringSetAsync(formattedKey, ToJson(obj), expire);

            return obj;

        });
    }

    public override async Task<bool> IsExistsAsync(string key) => await ExecuteAsync(async db => await db.KeyExistsAsync(FormatKey(key)));

    public override async Task<bool> RemoveAsync(string key) => await ExecuteAsync(async db => await db.KeyDeleteAsync(FormatKey(key)));

    private async Task<TResult> ExecuteAsync<TResult>(Func<IDatabase, Task<TResult>> main)
    {
        if (!IsConnected)
        {
            return default;
        }

        try
        {
            var db = _lazyConnection?.Value?.GetDatabase(_database);
            return await main(db);
        }
        catch (Exception ex)
        {
            if (!string.IsNullOrWhiteSpace(ex.Source) && ex.Source.Contains("StackExchange", StringComparison.OrdinalIgnoreCase))
            {
                Connect(force: true);
            }

            return default;
        }
    }

    #region Private

    private string FormatKey(string key) => $"{_prefix}{key.Trim(':')}";

    private string ToJson(object source)
    {
        try
        {
            return JsonHelper.AsJson(source, JsonSettings);
        }
        catch
        {
            return string.Empty;
        }
    }

    private T ToObj<T>(string json)
    {
        if (string.IsNullOrWhiteSpace(json))
        {
            return default;
        }

        try
        {
            return JsonHelper.AsObject<T>(json, JsonSettings);
        }
        catch
        {
            return default;
        }
    }

    #endregion

    #region Connection

    private static Lazy<ConnectionMultiplexer> _lazyConnection;

    public bool IsConnected
    {
        get
        {
            try
            {
                return !string.IsNullOrWhiteSpace(_connectionString) && (_lazyConnection?.Value?.IsConnected ?? false);
            }
            catch // (Exception ex)
            {
                return false;
            }
        }
    }

    private void Connect(bool force = false)
    {
        if (string.IsNullOrWhiteSpace(_connectionString))
        {
            return;
        }

        if (force)
        {
            _lazyConnection = null; // will force re-init
        }

        if (IsConnected)
        {
            return;
        }

        _lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            ConnectionMultiplexer muxer = null;

            try
            {
                muxer = ConnectionMultiplexer.Connect(_connectionString);
                //muxer.ConnectionFailed += (sender, e) => { };
                //muxer.InternalError += (sender, e) => { };
            }
            catch // (Exception ex)
            {
            }

            return muxer;
        });
    }

    #endregion
}
