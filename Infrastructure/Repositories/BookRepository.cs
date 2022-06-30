using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Settings;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRespository
    {
        private readonly IMongoCollection<Book> _book;

        public BookRepository(IMongoDbSetting setting)
        {
            var client = new MongoClient(setting.ConnectionString);
            var db = client.GetDatabase(setting.DatabaseName);

            _book = db.GetCollection<Book>("Books");
        }

        public async Task<Book> GetByIdAsync(string id)
        {
            return await _book.Find(w => w.Id == id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Book>> GetListAsync()
        {
            return await _book.Find(w => true).ToListAsync();
        }
        public async Task AddAsync(Book book)
        {
            await _book.InsertOneAsync(book);
        }
    }
}