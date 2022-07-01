using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? DeletedOn { get; set; }
        public string? DeletedBy { get; set; }

        public void SetCreated()
        {
            CreatedOn = DateTime.UtcNow;
            // CreatedBy = _accessor.GetUserId();
            UpdatedOn = DateTime.UtcNow;
            // UpdatedBy = _accessor.GetUserId();
        }

        public void SetUpdated(string userId)
        {
            UpdatedOn = DateTime.UtcNow;
            // UpdatedBy = _accessor.GetUserId();
        }

        public void SetDeleted(string userId)
        {
            DeletedOn = DateTime.UtcNow;
            // DeletedBy = _accessor.GetUserId();
        }
    }
}