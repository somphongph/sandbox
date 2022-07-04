namespace Infrastructure.Settings
{
    public interface IRedisDbSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}