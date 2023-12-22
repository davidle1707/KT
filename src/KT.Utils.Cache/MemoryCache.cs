using Microsoft.Extensions.Caching.Memory;

namespace KT.Utils.Cache;

public class MemoryCache : NoCache, ICache
{
    private readonly IMemoryCache _memory;

    public MemoryCache(IMemoryCache memoryCache)
    {
        _memory = memoryCache;
    }

    public override async Task<bool> AddAsync<T>(string key, T value, TimeSpan? expire = null)
    {
        var obj = expire != null ? _memory.Set(key, value, expire.Value) : _memory.Set(key, value);
        return await Task.FromResult(obj != null);
    }

    public override async Task<T> GetAsync<T>(string key)
    {
        return await Task.FromResult(_memory.TryGetValue<T>(key, out var value) ? value : default);
    }

    public override async Task<T> GetOrAddAsync<T>(string key, Func<Task<T>> addAsync, TimeSpan? expire = null)
    {
        if (_memory.TryGetValue<T>(key, out var value))
        {
            return value;
        }

        value = await addAsync();
        _ = expire != null ? _memory.Set(key, value, expire.Value) : _memory.Set(key, value);

        return value;
    }

    public override async Task<bool> IsExistsAsync(string key)
    {
        return await Task.FromResult(_memory.TryGetValue(key, out _));
    }

    public override async Task<bool> RemoveAsync(string key)
    {
        _memory.Remove(key);
        return await Task.FromResult(true);
    }
}