using Domain.Entities;
using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface IBookService
    {
        Task<BookResponse> GetByIdAsync(string id);
        Task<IEnumerable<Book>> ListBookAsync();
        Task AddBookAsync(Book book);
    }
}