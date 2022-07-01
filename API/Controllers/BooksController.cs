
using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Services.Books.Commands.AddBook;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly ILogger<BooksController> _logger;
    private readonly IBookService _bookService;
    private readonly IMediator _mediator;


    public BooksController(ILogger<BooksController> logger, IMediator mediator, IBookService bookService)
    {
        _logger = logger;
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
    }

    [HttpGet("{id}")]
    public async Task<BookResponse> Get(string id)
    {
        return await _bookService.GetByIdAsync(id);
    }

    [HttpGet]
    public async Task<IEnumerable<Book>> GetList()
    {
        return await _bookService.ListBookAsync();
    }

    // [HttpPost]
    // public async void Post(BookRequest book)
    // {
    //     await _bookService.AddBookAsync(book);
    // }

    [HttpPost]
    public async Task<ActionResult> Post(AddBookCommand command)
    {
        var res = await _mediator.Send(command);

        return CreatedAtAction(null, res);
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
