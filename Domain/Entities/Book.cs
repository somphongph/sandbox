using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class Book : BaseEntity
    {
        public Locale Name { get; set; } = new Locale();
        public string Title { get; set; } = String.Empty;
    }
}