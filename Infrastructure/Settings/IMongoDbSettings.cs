namespace Infrastructure.Settings
{
    public interface IMongoDbSettings
    {
<<<<<<< HEAD
        public string ConnectionString { get; set; } = String.Empty;    
        public string DatabaseName { get; set; } = String.Empty;
=======
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
>>>>>>> 3d00f0ba82fdc5e7fc884dd66c1b4de879a77941
    }
}