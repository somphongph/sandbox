using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
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

        public async Task<CategoryResponse> GetByIdAsync(string id)
        {
            var book = await _categoryRepository.GetByIdAsync(id);

            return new CategoryResponse()
            {
                Name = book.Name.ToString(),
                Title = book.Title,
            };
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.GetListAsync();
        }
    }
}