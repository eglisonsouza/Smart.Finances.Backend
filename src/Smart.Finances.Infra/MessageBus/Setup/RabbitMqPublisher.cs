using RabbitMQ.Client;

namespace Smart.Finances.Infra.MessageBus.Setup
{
    public class RabbitMqPublisher
    {
        private readonly ConnectionFactory _factory;

        public RabbitMqPublisher()
        {
            _factory = RabbitMqSetup.CreateConnectionFactory();
        }

        protected void Publish(string queue, byte[] message)
        {
            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    RabbitMqSetup.DeclareQueue(channel, queue);
                    Send(queue, message, channel);
                }
            }
        }

        private static void Send(string queue, byte[] message, IModel channel)
        {
            channel.BasicPublish(
                exchange: "",
                routingKey: queue,
                basicProperties: null,
                body: message);
        }
    }
}
