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
        public async Task<IEnumerable<Book>> GetListAsync()
        {
            return await _books
                .Find(_ => true)
                .ToListAsync();
        }
        public async Task AddAsync(Book book)
        {
            // book.SetCreated(_accessor.GetUserId());
            await _books
                .InsertOneAsync(book);
        }
    }
}