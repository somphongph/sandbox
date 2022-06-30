using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> ListBookAsync();
        Task AddBookAsync(Book book);
    }
}