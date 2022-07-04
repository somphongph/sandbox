using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models.Request;
using Domain.Models.Response;

namespace Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public async Task<CategoryResponse> GetByIdAsync(string id)
        {
            var book = await _categoryRepository.GetByIdAsync(id);

            return new CategoryResponse()
            {
                Name = book.Name.ToString(),
                Title = book.Title,
            };
        }

        public async Task<IEnumerable<CategoryResponse>> GetListAsync()
        {
            var categories = await _categoryRepository.GetCacheListAsync();
            return categories.Select(b => new CategoryResponse()
            {
                Name = b.Name.ToString(),
                Title = b.Title
            });
        }

        public async Task AddAsync(CategoryRequest req)
        {
            var category = new Category()
            {
                Name = req.Name,
                Title = req.Title,
            };

            await _categoryRepository.AddAsync(category);
        }
    }
}