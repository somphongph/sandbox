using System.Text.Json;
using Domain.Entities;
using Domain.Interfaces.CacheRepositories;
using Domain.Interfaces.Repositories;
using Infrastructure.Settings;
using Microsoft.Extensions.Caching.Distributed;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoCollection<Category> _categories;
        private readonly IRedisRepository _redisRepository;

        public CategoryRepository(IMongoDbSettings settings, IRedisRepository redisRepository)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _categories = database.GetCollection<Category>("Categories");
            _redisRepository = redisRepository ?? throw new ArgumentNullException(nameof(redisRepository));
        }

        public async Task<Category> GetByIdAsync(string id)
        {
            return await _categories
                .Find(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> GetCacheListAsync()
        {
            var categories = await GetListAsync();

            var result = await _redisRepository.AddCacheLongAsync("categories", categories);

            return result ?? new List<Category>();
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