using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Models.common;
using MediatR;
using MongoDB.Driver;

namespace Domain.Services.Books.Queries.GetBookList
{
    public class GetBookListHandler : IRequestHandler<GetBookListQuery, QueryListResponse<GetBookListResponse>>
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

        public async Task<QueryListResponse<GetBookListResponse>> Handle(GetBookListQuery request, CancellationToken cancellationToken)
        {
            var builder = Builders<Book>.Filter;
            var filter = builder.Empty;

            // Post
            var bookListResponse = new List<GetBookListResponse>();

            var books = await _bookRepository.GetListAsync(filter, request.PageNo, request.PageSize);

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

            return new QueryListResponse<GetBookListResponse>()
            {
                IsCached = false,
                Data = bookListResponse,
                Total = await _bookRepository.GetCountAsync(filter),
                PageNo = request.PageNo,
                PageSize = request.PageSize
            };
        }
    }
}