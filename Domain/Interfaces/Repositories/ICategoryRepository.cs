using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetByIdAsync(string id);

        Task<IEnumerable<Category>> GetCacheListAsync();
        Task<IEnumerable<Category>> GetListAsync();
        Task AddAsync(Category obj);
        Task<bool> UpdateAsync(Category obj);
        Task<bool> DeleteAsync(Category obj);
    }
}