namespace Infrastructure.Settings
{
    public interface IMongoDbSettings
    {
        public string ConnectionString { get; set; } = String.Empty;    
        public string DatabaseName { get; set; } = String.Empty;
    }
}