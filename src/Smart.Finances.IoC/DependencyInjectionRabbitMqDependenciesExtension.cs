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
            services.AddSingleton<IExpenseQueueConsumer, ExpenseQueueConsumer>();
            services.AddSingleton<INotificationQueuePublisher, NotificationQueuePublisher>();

            services.AddHostedService<RabbitMqConsumerSetup<IExpenseQueueConsumer>>();

            return services;
        }
    }
}
