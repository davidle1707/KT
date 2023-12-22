namespace KT.Utils.Cache;

public class NoCache : ICache
{
    public virtual async Task<bool> AddAsync<T>(string key, T value, TimeSpan? expire = null)
    {
        return await Task.FromResult(true);
    }

    public virtual async Task<T> GetAsync<T>(string key)
    {

        return await Task.FromResult(default(T));
    }

    public virtual async Task<T> GetOrAddAsync<T>(string key, Func<Task<T>> addAsync, TimeSpan? expire = null)
    {
        return await addAsync();
    }

    public virtual async Task<bool> IsExistsAsync(string key)
    {
        return await Task.FromResult(false);
    }

    public virtual async Task<bool> RemoveAsync(string key)
    {
        return await Task.FromResult(true);
    }
}
