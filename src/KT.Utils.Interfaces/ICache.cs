namespace KT.Utils.Interfaces;

public interface ICache
{
    Task<bool> AddAsync<T>(string key, T value, TimeSpan? expire = null);

    Task<T> GetAsync<T>(string key);

    Task<T> GetOrAddAsync<T>(string key, Func<Task<T>> addAsync, TimeSpan? expire = null);

    Task<bool> RemoveAsync(string key);

    Task<bool> IsExistsAsync(string key);
}
