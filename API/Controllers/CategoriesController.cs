using Domain.Interfaces.Services;
using Domain.Models.Request;
using Domain.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ILogger<CategoriesController> _logger;
    private readonly ICategoryService _categoryService;

    public CategoriesController(ILogger<CategoriesController> logger, ICategoryService categoryService)
    {
        _logger = logger;
        _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
    }

    [HttpGet("{id}")]
    public async Task<CategoryResponse> Get(string id)
    {
        return await _categoryService.GetByIdAsync(id);
    }

    [HttpGet]
    public async Task<IEnumerable<CategoryResponse>> GetList()
    {
        return await _categoryService.GetListAsync();
    }

    [HttpPost]
    public async void Post(CategoryRequest book)
    {
        await _categoryService.AddAsync(book);
    }



    // [HttpPut]
    // public IEnumerable<Book> Put()
    // {
    //     return new List<Book>()
    //     {
    //         new Book(){
    //             Name = "book 1",
    //             Title = "Title 1"
    //         },
    //         new Book(){
    //             Name = "Books 2",
    //             Title = "Title 2"
    //         }
    //     };
    // }

    // [HttpDelete]
    // public IEnumerable<Book> Delete()
    // {
    //     return new List<Book>()
    //     {
    //         new Book(){
    //             Name = "book 1",
    //             Title = "Title 1"
    //         },
    //         new Book(){
    //             Name = "Books 2",
    //             Title = "Title 2"
    //         }
    //     };
    // }
}