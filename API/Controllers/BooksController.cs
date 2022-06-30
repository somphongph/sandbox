using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly ILogger<BooksController> _logger;

    public BooksController(ILogger<BooksController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Book> Get()
    {
        return new List<Book>()
        {
            new Book(){
                Name = "book 1",
                Title = "Title 1"
            },
            new Book(){
                Name = "Books 2",
                Title = "Title 2"
            }
        };
    }
}
