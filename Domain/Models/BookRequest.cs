using Domain.Entities;

namespace Domain.Models
{
    public class BookRequest
    {
        public Locale Name { get; set; } = new Locale();
        public string Title { get; set; } = String.Empty;
    }
}