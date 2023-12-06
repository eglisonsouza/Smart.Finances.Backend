using RabbitMQ.Client;
using Smart.Finances.Core.Model.UI;

namespace Smart.Finances.Infra.MessageBus.Setup
{
    public class RabbitMqSetup
    {
        public static ConnectionFactory CreateConnectionFactory(RabbitMqSettings rabbitMq)
        {
#if DEBUG
            return new ConnectionFactory
            {
                HostName = rabbitMq.Host!,
                UserName = rabbitMq.User!,
                Password = rabbitMq.Password!,
            };
#else
            return new ConnectionFactory
            {
                Uri = new Uri(rabbitMq.Uri!),
            };
#endif
        }

        public static void DeclareQueue(IModel channel, string queue)
        {
            channel.QueueDeclare(
                queue: queue,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }
    }
}
