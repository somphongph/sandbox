using Domain.Entities;
using Domain.Interfaces.Repositories;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IMongoCollection<Book> _books;

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
    }
}