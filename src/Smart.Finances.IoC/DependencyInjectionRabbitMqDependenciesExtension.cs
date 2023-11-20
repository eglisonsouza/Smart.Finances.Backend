using Microsoft.Extensions.DependencyInjection;
using Smart.Finances.Infra.MessageBus.Queues.Consumers;
using Smart.Finances.Infra.MessageBus.Queues.Publishers;
using Smart.Finances.Infra.MessageBus.Setup;

namespace Smart.Finances.IoC
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
