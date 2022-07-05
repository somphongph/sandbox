using Infrastructure.Settings;
using Domain.Interfaces.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Domain.Interfaces.CacheRepositories;
using Infrastructure.CacheRepository;
using Domain.Entities;

namespace Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region MongoDB
            services.Configure<MongoDbSettings>(
                configuration.GetSection(nameof(MongoDbSettings)));

            services.AddSingleton<IMongoDbSettings>(sp =>
                sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);
            #endregion

            #region Redis
            var redisDbSettings = configuration.GetSection(nameof(RedisDbSettings)).Get<RedisDbSettings>();

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = redisDbSettings.ConnectionString;
                options.InstanceName = redisDbSettings.DatabaseName;
            });
            #endregion

            #region Cache
            // services.AddSingleton<IRedisRepository, RedisRepository>();
            #endregion

            #region Repositories dependency injection
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            #endregion



            return services;
        }
    }
}