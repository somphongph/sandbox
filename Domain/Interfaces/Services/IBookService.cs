using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IBookService
    {
         Task<IEnumerable<Book>> List();
    }
}