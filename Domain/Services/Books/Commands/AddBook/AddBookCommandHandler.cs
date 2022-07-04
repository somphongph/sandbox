using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Domain.Models.common;
using MediatR;

namespace Domain.Services.Books.Commands.AddBook
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, CommandResponse>
    {
        private readonly IBookRepository _bookRepository;

        public AddBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public async Task<CommandResponse> Handle(AddBookCommand request, CancellationToken cancellationToken)
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
            return new CommandResponse()
            {
                Id = book.Id
            };
        }
    }
}