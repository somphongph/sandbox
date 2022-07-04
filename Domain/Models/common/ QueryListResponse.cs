namespace Domain.Models.common
{
    public class QueryListResponse<T> : BaseQueryResponse
    {
        public IEnumerable<T>? Data { get; set; }
    }
}