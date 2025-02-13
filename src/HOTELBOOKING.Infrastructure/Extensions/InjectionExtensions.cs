using HOTELBOOKING.Application.Interface.Authentication;
using HOTELBOOKING.Application.Interface.Services;
using HOTELBOOKING.Infrastructure.Authentication;
using HOTELBOOKING.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HOTELBOOKING.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();
            services.AddScoped<IPermissionService, PermissionService>();

            services.AddSingleton<IEmailService, EmailService>();

            return services;
        }
    }
}
