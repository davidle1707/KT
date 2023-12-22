using System.Collections.Concurrent;

namespace KT.Utils.Cache;

public class StaticCache : NoCache, ICache
{
    private static readonly ConcurrentDictionary<string, object> _stores = new();

    public override async Task<bool> AddAsync<T>(string key, T value, TimeSpan? expire = null)
    {
        _stores.AddOrUpdate(key, value, (existingKey, existingValue) => existingValue);
        return await Task.FromResult(true);
    }

    public override async Task<T> GetAsync<T>(string key)
    {
        var value = _stores.TryGetValue(key, out var obj) ? (T)obj : default;
        return await Task.FromResult(value);
    }

    public override async Task<T> GetOrAddAsync<T>(string key, Func<Task<T>> addAsync, TimeSpan? expire = null)
    {
        if (_stores.ContainsKey(key))
        {
            return (T)_stores[key];
        }

        var value = await addAsync();
        _stores.AddOrUpdate(key, value, (existingKey, existingValue) => existingValue);

        return await Task.FromResult(value);
    }

    public override async Task<bool> IsExistsAsync(string key)
    {
        return await Task.FromResult(_stores.ContainsKey(key));
    }

    public override async Task<bool> RemoveAsync(string key)
    {
        var success = _stores.ContainsKey(key) && _stores.TryRemove(key, out _);
        return await Task.FromResult(success);
    }
}