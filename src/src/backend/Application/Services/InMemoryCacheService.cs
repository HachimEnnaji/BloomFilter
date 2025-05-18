using BloomFilter.Core.Interfaces;

namespace BloomFilter.Application.Services;

public class InMemoryCacheService<T> : ICacheService<T> where T : class
{
    private readonly Dictionary<string, T> _memberCache = [];

    public Task DeleteAsync(string key)
    {
        _memberCache.Remove(key);
        return Task.CompletedTask;
    }

    public Task<bool> ExistAsync(string key)
    {
        return Task.FromResult(_memberCache.ContainsKey(key));
    }

    public Task<T?> GetAsync(string key)
    {
        _memberCache.TryGetValue(key, out var value);
        return Task.FromResult(value);
    }

    public Task SetAsync(string key, T value, TimeSpan? timeExpiration = null)
    {
        _memberCache[key] = value;
        return Task.CompletedTask;
    }
}
