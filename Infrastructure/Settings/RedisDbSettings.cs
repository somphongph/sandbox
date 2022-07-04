namespace Infrastructure.Settings
{
    public class RedisDbSettings : IRedisDbSettings
    {
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}