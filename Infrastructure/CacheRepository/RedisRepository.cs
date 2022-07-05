using System.Text.Json;
using Domain.Interfaces.CacheRepositories;
using Infrastructure.Settings;
using Microsoft.Extensions.Caching.Distributed;

namespace Infrastructure.CacheRepository
{
    public class RedisRepository : IRedisRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IRedisDbSettings _redisDbSettings;
        public RedisRepository(IDistributedCache distributedCache, IRedisDbSettings redisDbSettings)
        {
            _distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));
            _redisDbSettings = redisDbSettings ?? throw new ArgumentNullException(nameof(redisDbSettings));
        }

        public async Task<T?> AddCacheShortAsync<T>(string key, T data)
        {
            return await AddCacheAsync(key, data, _redisDbSettings.ExpireShort);
        }

        public async Task<T?> AddCacheLongAsync<T>(string key, T data)
        {
            return await AddCacheAsync(key, data, _redisDbSettings.ExpireLong);
        }

        public async Task<T?> AddCacheAsync<T>(string key, T data, int expires)
        {
            var cache = await _distributedCache.GetStringAsync(key);

            if (String.IsNullOrEmpty(cache))
            {
                var json = JsonSerializer.Serialize(data);
                var opt = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(expires));

                await _distributedCache.SetStringAsync(key, json, opt);

                cache = json;
            }

            return JsonSerializer.Deserialize<T>(cache);
        }

        public async Task<T?> AddCacheSlidingAsync<T>(string key, T data, int expires)
        {
            var cache = await _distributedCache.GetStringAsync(key);

            if (String.IsNullOrEmpty(cache))
            {
                var json = JsonSerializer.Serialize(data);
                var opt = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(expires));

                await _distributedCache.SetStringAsync(key, json, opt);

                cache = json;
            }

            return JsonSerializer.Deserialize<T>(cache);
        }

        public async Task RemoveCacheAsync(string key)
        {
            await _distributedCache.RemoveAsync(key);
        }
    }
}