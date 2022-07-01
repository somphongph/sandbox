using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces.Services;
using Domain.Services;

namespace Domain
{
    public static class DomainRegistration
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            #region Repositories dependency injection
            services.AddScoped<IBookService, BookService>();

            #endregion

            return services;
        }
    }
}