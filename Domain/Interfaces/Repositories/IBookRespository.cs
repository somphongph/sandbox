using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IBookRespository
    {
        Task<Book> GetByIdAsync(string id);
        Task<IEnumerable<Book>> GetListAsync();
        Task AddAsync(Book book);
    }
}