namespace Infrastructure.Settings
{
    public interface IRedisDbSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        int ExpireShort { get; set; }
        int ExpireLong { get; set; }
    }
}