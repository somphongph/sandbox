namespace Domain.Models.common
{
    public class QueryListResponse<T> : BaseQueryResponse
    {
        public IEnumerable<T>? Data { get; set; }
        public long Total { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
    }
}