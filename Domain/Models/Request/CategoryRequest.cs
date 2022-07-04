namespace Domain.Models.Request
{
    public class CategoryRequest
    {
        public Locale Name { get; set; } = new Locale();
        public string Title { get; set; } = String.Empty;
    }
}