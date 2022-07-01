using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IBookService
    {
        Task<Book> GetByIdAsync(string id);
        Task<IEnumerable<Book>> ListBookAsync();
        Task AddBookAsync(Book book);
    }
}