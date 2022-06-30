namespace Infrastructure.Settings
{
<<<<<<< HEAD
    public class MongoDbSettings
    {
        
=======
    public class MongoDbSettings : IMongoDbSettings
    {
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
>>>>>>> 3d00f0ba82fdc5e7fc884dd66c1b4de879a77941
    }
}