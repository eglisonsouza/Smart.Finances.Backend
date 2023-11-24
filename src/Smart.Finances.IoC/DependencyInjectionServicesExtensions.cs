using Microsoft.Extensions.DependencyInjection;
using Smart.Finances.Core.Services;
using Smart.Finances.Infra.Services;

namespace Smart.Finances.IoC
{
    public static class DependencyInjectionServicesExtensions
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}
