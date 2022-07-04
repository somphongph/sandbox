using Domain.Models.common;
using MediatR;

namespace Domain.Services.Books.Queries.GetBookList
{
    public class GetBookListQuery : IRequest<QueryListResponse<GetBookListResponse>>
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
    }
}