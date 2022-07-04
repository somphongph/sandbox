using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Domain.Services.Books.Commands.AddBook
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, AddBookResponse>
    {
        private readonly IBookRepository _bookRepository;

        public AddBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public async Task<AddBookResponse> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            // Add Post
            var book = new Book()
            {
                Name = new Locale()
                {
                    Th = request.NameTh,
                    En = request.NameEn,
                },
                Title = request.Title,
            };


            await _bookRepository.AddAsync(book);

            // Response
            return new AddBookResponse()
            {
                Name = book.Name.ToString(),
                Title = book.Title
            };
        }
    }
}