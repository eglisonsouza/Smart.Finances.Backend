using Microsoft.Extensions.DependencyInjection;
using Smart.Finances.DataAccess.Core.Services;
using Smart.Finances.DataAccess.Infra.Services;

namespace Smart.Finances.DataAccess.IoC
{
    public static class DependencyInjectionServicesExtensions
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
