using Domain.Entities;
<<<<<<< HEAD
using Domain.Interfaces.Repositories;
=======
>>>>>>> 3d00f0ba82fdc5e7fc884dd66c1b4de879a77941

namespace Domain.Interfaces.Repositories
{
    public interface IBookRepository
    {
<<<<<<< HEAD
         Task<Book> GetByIdAsync(string id);
=======
        Task<Book> GetByIdAsync(string id);
>>>>>>> 3d00f0ba82fdc5e7fc884dd66c1b4de879a77941
        Task<IEnumerable<Book>> GetListAsync();
        Task AddAsync(Book book);
    }
}