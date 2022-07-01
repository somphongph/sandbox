using Domain.Entities;
using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<CategoryResponse> GetByIdAsync(string id);
        Task<IEnumerable<Category>> ListAsync();
        Task AddAsync(CategoryRequest category);
    }
}