using Eg.rel.AuthService.Services.Interfaces;

namespace Eg.rel.AuthService.Services.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorizationService, AuthorizationService>();
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}
