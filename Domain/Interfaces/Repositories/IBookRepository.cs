using Domain.Entities;
using MongoDB.Driver;

namespace Domain.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task<Book> GetByIdAsync(string id);
        Task<IEnumerable<Book>> GetListAsync(FilterDefinition<Book> filter, int pageNo, int pageSize);

        Task<long> GetCountAsync(FilterDefinition<Book> filter);
        Task AddAsync(Book obj);
        Task<bool> UpdateAsync(Book obj);
        Task<bool> DeleteAsync(Book obj);
    }
}