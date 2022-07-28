using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;
using Application.Persistence.Contracts;

namespace Persistence
{
    public static class ServicesPersistenceRegistration
    {
        public static IServiceCollection ConfigureServicesPersistence(this IServiceCollection services)
        {
            services.AddDbContext<MyContext>(opt =>
            {
                opt.UseInMemoryDatabase("CQRS_DB");
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICostumerRepository, CostumerRepository>();


            return services;
        }
    }
}
