namespace Domain.Interfaces.CacheRepositories
{
    public interface IRedisRepository
    {
        Task<T?> AddCacheShortAsync<T>(string key, T data);
        Task<T?> AddCacheLongAsync<T>(string key, T data);
        Task<T?> AddCacheAsync<T>(string key, T data, int expires);
        Task<T?> AddCacheSlidingAsync<T>(string key, T data, int expires);
        Task RemoveCacheAsync(string key);
    }
}