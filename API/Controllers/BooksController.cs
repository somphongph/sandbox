using Domain.Services.Books.Commands.AddBook;
using Domain.Services.Books.Queries.GetBookList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly ILogger<BooksController> _logger;
    private readonly IMediator _mediator;

    public BooksController(ILogger<BooksController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    // [HttpGet("{id}")]
    // public async Task<BookResponse> Get(string id)
    // {
    //     return await _bookService.GetByIdAsync(id);
    // }

    [HttpGet]
    public async Task<IEnumerable<GetBookListResponse>> GetList([FromQuery] GetBookListQuery query)
    {
        return await _mediator.Send(query);
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
