using System.Text.Json;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Settings;
using Microsoft.Extensions.Caching.Distributed;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoCollection<Category> _categories;
        private readonly IDistributedCache _distributedCache;

        public CategoryRepository(IMongoDbSettings settings, IDistributedCache distributedCache)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _categories = database.GetCollection<Category>("Categories");
            _distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));
        }

        public async Task<Category> GetByIdAsync(string id)
        {
            return await _categories
                .Find(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> GetCacheListAsync()
        {
            var cacheKey = $"-category";
            var cached = await _distributedCache.GetStringAsync(cacheKey);

            if (String.IsNullOrEmpty(cached))
            {
                var cate = await GetListAsync();
                var redisData = JsonSerializer.Serialize(cate.ToList());
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(60));

                await _distributedCache.SetStringAsync(cacheKey, redisData, options);

                cached = redisData;
            }
            var res = JsonSerializer.Deserialize<List<Category>>(cached);

            return res ?? new List<Category>();
        }

        public async Task<IEnumerable<Category>> GetListAsync()
        {
            return await _categories
                .Find(_ => true)
                .ToListAsync();
        }

        public async Task AddAsync(Category obj)
        {
            await _categories.InsertOneAsync(obj);
        }

        public async Task<bool> UpdateAsync(Category obj)
        {
            var result = await _categories.ReplaceOneAsync(p => p.Id == obj.Id, obj);

            return result.IsAcknowledged
                    && result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteAsync(Category obj)
        {
            var result = await _categories.ReplaceOneAsync(p => p.Id == obj.Id, obj);

            return result.IsAcknowledged
                    && result.ModifiedCount > 0;
        }
    }
}