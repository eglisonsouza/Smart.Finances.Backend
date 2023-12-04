using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smart.Finances.Core.Model.UI;

namespace Smart.Finances.IoC.Config
{
    public static class GeneralConfig
    {
        public static IServiceCollection AddSettingsConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetSection("Settings").Get<ApiSettings>()!);

            return services;
        }

        public static IServiceCollection AddCorsConfig(this IServiceCollection services, string anyOriginCors)
        {
            services.AddCors(options =>
            {
                options.AddPolicy
                    (
                        name: anyOriginCors,
                        policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
                    );
            });

            return services;
        }
    }
}
