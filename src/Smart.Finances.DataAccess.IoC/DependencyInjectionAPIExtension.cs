using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Smart.Finances.DataAccess.IoC
{
    public static class DependencyInjectionAPIExtension
    {
        public static IServiceCollection AddInfraestructureApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddContextSqlServer(configuration);

            services.AddRepository();

            services.AddRequestHandler();

            services.AddRabbitMq();

            return services;
        }
    }
}
