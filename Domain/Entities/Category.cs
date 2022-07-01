namespace Domain.Entities
{
    public class Category : BaseEntity
    {
        public Locale Name { get; set; } = new Locale();
        public string Title { get; set; } = String.Empty;
    }
}