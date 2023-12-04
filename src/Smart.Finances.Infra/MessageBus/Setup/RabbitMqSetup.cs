using RabbitMQ.Client;
using Smart.Finances.Core.Model.UI;

namespace Smart.Finances.Infra.MessageBus.Setup
{
    public class RabbitMqSetup
    {
        public static ConnectionFactory CreateConnectionFactory(RabbitMqSettings rabbitMq)
        {
            return new ConnectionFactory
            {
                HostName = rabbitMq.Host,
                Password = rabbitMq.Password,
                UserName = rabbitMq.User,
            };
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
