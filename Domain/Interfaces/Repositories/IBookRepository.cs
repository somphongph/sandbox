using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task<Book> GetByIdAsync(string id);
        Task<IEnumerable<Book>> GetListAsync();
        Task AddAsync(Book obj);
        Task<bool> UpdateAsync(Book obj);
        Task<bool> DeleteAsync(Book obj);
    }
}