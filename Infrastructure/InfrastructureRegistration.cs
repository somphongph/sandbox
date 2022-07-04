using Infrastructure.Settings;
using Domain.Interfaces.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

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
            var rd = configuration.GetSection(nameof(RedisDbSettings)).Get<RedisDbSettings>();

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = rd.ConnectionString;
                options.InstanceName = rd.DatabaseName;
            });
            #endregion

            #region Repositories dependency injection
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            #endregion

            return services;
        }
    }
}