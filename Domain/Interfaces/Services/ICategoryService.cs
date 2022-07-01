using Domain.Models.Request;
using Domain.Models.Response;

namespace Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<CategoryResponse> GetByIdAsync(string id);
        Task<IEnumerable<CategoryResponse>> GetListAsync();
        Task AddAsync(CategoryRequest category);
    }
}