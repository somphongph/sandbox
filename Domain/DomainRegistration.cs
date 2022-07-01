using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Domain.Services.Books.Commands.AddBook;
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

            #region MediatR
            services.AddMediatR(typeof(AddBookCommandHandler));
            #endregion

            return services;
        }
    }
}