
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly ILogger<BooksController> _logger;
    private readonly IBookService _bookService;


    public BooksController(ILogger<BooksController> logger, IBookService bookService)
    {
        _logger = logger;
        _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
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

    [HttpGet]
    public IEnumerable<Book> GetList()
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

    [HttpPost]
    public async void Post(Book book)
    {
        await _bookService.AddBookAsync(book);
    }

    [HttpPut]
    public IEnumerable<Book> Put()
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

    [HttpDelete]
    public IEnumerable<Book> Delete()
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
