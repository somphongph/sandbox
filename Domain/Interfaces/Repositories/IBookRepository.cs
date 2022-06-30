using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task<Book> GetByIdAsync(string id);
        Task<IEnumerable<Book>> GetListAsync();
        Task AddAsync(Book book);
    }
}