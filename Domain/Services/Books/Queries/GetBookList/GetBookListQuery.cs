using MediatR;

namespace Domain.Services.Books.Queries.GetBookList
{
    public class GetBookListQuery : IRequest<IEnumerable<GetBookListResponse>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}