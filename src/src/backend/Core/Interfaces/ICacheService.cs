namespace BloomFilter.Core.Interfaces;
public interface ICacheService<T> where T : class
{
    Task SetAsync(string key, T value, TimeSpan? timeExpiration = null);
    Task<T?> GetAsync(string key);
    Task<bool> ExistAsync(string key);
    Task DeleteAsync(string key);
}
