using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Settings;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IMongoCollection<Book> _books;

        public BookRepository(IMongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Book>("Books");
        }

        public async Task<Book> GetByIdAsync(string id)
        {
            return await _books
                .Find(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Book>> GetListAsync(FilterDefinition<Book> filter, int pageNo, int pageSize)
        {
            return await _books
                .Find(filter)
                .Skip((pageNo - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync();
        }

        public async Task<long> GetCountAsync(FilterDefinition<Book> filter)
        {
            return await _books
                .Find(filter)
                .CountDocumentsAsync();
        }

        public async Task AddAsync(Book obj)
        {
            await _books.InsertOneAsync(obj);
        }

        public async Task<bool> UpdateAsync(Book obj)
        {
            var result = await _books.ReplaceOneAsync(p => p.Id == obj.Id, obj);

            return result.IsAcknowledged
                    && result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteAsync(Book obj)
        {
            var result = await _books.ReplaceOneAsync(p => p.Id == obj.Id, obj);

            return result.IsAcknowledged
                    && result.ModifiedCount > 0;
        }
    }
}