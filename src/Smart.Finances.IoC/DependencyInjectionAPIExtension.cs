using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smart.Finances.Core.Model.UI;

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
