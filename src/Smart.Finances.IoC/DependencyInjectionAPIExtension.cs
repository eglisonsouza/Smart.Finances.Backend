using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Smart.Finances.IoC
{
    public static class DependencyInjectionAPIExtension
    {
        public static IServiceCollection AddInfraestructureApi(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddContextSqlServer(configuration)
                .AddRepository()
                .AddService()
                .AddRequestHandler()
                .AddRabbitMq();

            return services;
        }
    }
}
