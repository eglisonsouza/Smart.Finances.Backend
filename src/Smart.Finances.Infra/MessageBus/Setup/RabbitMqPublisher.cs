using RabbitMQ.Client;
using Smart.Finances.Core.Model.UI;

namespace Smart.Finances.Infra.MessageBus.Setup
{
    public class RabbitMqPublisher
    {
        private readonly ConnectionFactory _factory;

        public RabbitMqPublisher(ApiSettings apiSettings)
        {
            _factory = RabbitMqSetup.CreateConnectionFactory(apiSettings.RabbitMq!);
        }

        protected void Publish(string queue, byte[] message)
        {
            using var model = _factory.CreateConnection().CreateModel();
            RabbitMqSetup.DeclareQueue(model, queue);
            Send(queue, message, model);
        }

        private static void Send(string queue, byte[] message, IModel model)
        {
            model.BasicPublish(
                exchange: "",
                routingKey: queue,
                basicProperties: null,
                body: message);
        }
    }
}
