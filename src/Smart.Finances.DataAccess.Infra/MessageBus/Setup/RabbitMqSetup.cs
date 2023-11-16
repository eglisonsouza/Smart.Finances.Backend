using RabbitMQ.Client;

namespace Smart.Finances.DataAccess.Infra.MessageBus.Setup
{
    public class RabbitMqSetup
    {
        public static ConnectionFactory CreateConnectionFactory()
        {
            return new ConnectionFactory
            {
                HostName = "192.168.112.1",
                Password = "guest",
                UserName = "guest",
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
