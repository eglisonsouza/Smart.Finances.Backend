using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smart.Finances.Infra.MessageBus.Queues.Publishers;

namespace Smart.Finances.IoC
{
    public static class DependencyInjectionRabbitMqDependenciesExtension
    {
        public static IServiceCollection AddRabbitMq(this IServiceCollection services)
        {
            services.AddScoped<INotificationQueuePublisher, NotificationQueuePublisher>();

            return services;
        }
    }
}
