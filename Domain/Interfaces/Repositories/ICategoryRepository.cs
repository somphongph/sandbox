using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetByIdAsync(string id);
        Task<IEnumerable<Category>> GetListAsync();
        Task AddAsync(Category category);
    }
}