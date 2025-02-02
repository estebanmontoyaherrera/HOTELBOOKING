using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Persistence.Context;
using HOTELBOOKING.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HOTELBOOKING.Persistence.Extension
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services)
        {
            services.AddSingleton<ApplicationDbContext>();


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
