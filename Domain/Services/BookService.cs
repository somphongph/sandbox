using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public async Task AddBookAsync(BookRequest bookRequest)
        {
            var book = new Book()
            {
                Name = bookRequest.Name,
                Title = bookRequest.Title,
            };

            await _bookRepository.AddAsync(book);
        }

        public async Task<BookResponse> GetByIdAsync(string id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            return new BookResponse()
            {
                Name = book.Name.ToString(),
                Title = book.Title,
            };
        }

        public async Task<IEnumerable<Book>> ListBookAsync()
        {
            return await _bookRepository.GetListAsync();
        }
    }
}