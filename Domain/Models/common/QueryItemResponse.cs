namespace Domain.Models.common
{
    public class QueryItemResponse<T> : BaseQueryResponse
    {
        public T? Data { get; set; }
    }
}