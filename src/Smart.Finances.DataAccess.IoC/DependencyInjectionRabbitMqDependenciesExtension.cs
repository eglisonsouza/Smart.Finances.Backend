using Microsoft.Extensions.DependencyInjection;
using Smart.Finances.DataAccess.Infra.MessageBus.Queues.Consumers;
using Smart.Finances.DataAccess.Infra.MessageBus.Queues.Publishers;
using Smart.Finances.DataAccess.Infra.MessageBus.Setup;

namespace Smart.Finances.DataAccess.IoC
{
    public static class DependencyInjectionRabbitMqDependenciesExtension
    {
        public static IServiceCollection AddRabbitMq(this IServiceCollection services)
        {
            services.AddSingleton<IDespesaQueueConsumer, DespesaQueueConsumer>();
            services.AddSingleton<IDespesaQueuePublisher, DespesaQueuePublisher>();

            services.AddHostedService<RabbitMqConsumerSetup<IDespesaQueueConsumer>>();

            return services;
        }
    }
}
