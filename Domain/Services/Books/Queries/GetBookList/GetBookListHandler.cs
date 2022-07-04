using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using MongoDB.Driver;

namespace Domain.Services.Books.Queries.GetBookList
{
    public class GetBookListHandler : IRequestHandler<GetBookListQuery, IEnumerable<GetBookListResponse>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookListHandler(
            // IHttpContextAccessor accessor,
            IBookRepository bookRepository
        )
        {
            // _accessor = accessor ?? throw new ArgumentNullException(nameof(accessor));
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public async Task<IEnumerable<GetBookListResponse>> Handle(GetBookListQuery request, CancellationToken cancellationToken)
        {
            var builder = Builders<Book>.Filter;
            var filter = builder.Empty;

            // Post
            var bookListResponse = new List<GetBookListResponse>();

            var books = await _bookRepository.GetListAsync();

            foreach (var p in books)
            {
                var postResponse = new GetBookListResponse()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Name = p.Name.ToString()
                };

                bookListResponse.Add(postResponse);
            }

            return bookListResponse;
            // return new GetBookListResponse()
            // {
            //     Data = bookListResponse,
            //     IsCached = false
            // };
        }
    }
}