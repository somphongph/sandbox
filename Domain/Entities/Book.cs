<<<<<<< HEAD
=======
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

>>>>>>> 3d00f0ba82fdc5e7fc884dd66c1b4de879a77941
namespace Domain.Entities
{
    public class Book
    {
<<<<<<< HEAD
        public string id { get;set; } = String.Empty;
=======
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
>>>>>>> 3d00f0ba82fdc5e7fc884dd66c1b4de879a77941
        public string Name { get; set; } = String.Empty;
        public string Title { get; set; } = String.Empty;
    }
}