using Domain.Entities;
using Domain.Interfaces.Repositories;
<<<<<<< HEAD
=======
using Infrastructure.Settings;
>>>>>>> 3d00f0ba82fdc5e7fc884dd66c1b4de879a77941
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IMongoCollection<Book> _books;

<<<<<<< HEAD
        public BookRepository(IMongoSettings)
        public async Task<Book> GetByIdAsync(string id)
        {
            return await _places
                .Find(p => p.Id == id && p.IsActive == true)
                .FirstOrDefaultAsync();
        }
        public async Task AddAsync(Book book)
        {
            place.SetCreated(_accessor.GetUserId());
            await _places.InsertOneAsync(place);
        }
=======
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
            return await _books.Find(_ => true).ToListAsync();
        }
        public async Task AddAsync(Book book)
        {
            await _books.InsertOneAsync(book);
        }


>>>>>>> 3d00f0ba82fdc5e7fc884dd66c1b4de879a77941
    }
}