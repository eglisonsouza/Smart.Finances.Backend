using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Smart.Finances.DataAccess.Core.Common.Consumers;

namespace Smart.Finances.DataAccess.Infra.MessageBus.Setup
{
    public class RabbitMqConsumerSetup<TQueue> : BackgroundService where TQueue : IQueue
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly TQueue _consumer;

        public RabbitMqConsumerSetup(TQueue consumer)
        {
            _connection = RabbitMqSetup.CreateConnectionFactory().CreateConnection();
            _channel = _connection.CreateModel();
            _consumer = consumer;
            RabbitMqSetup.DeclareQueue(_channel, _consumer.GetQueue());
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (sender, eventArgs) =>
            {
                _consumer.CallbackQueue();

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(_consumer.GetQueue(), false, consumer);
            return Task.CompletedTask;
        }
    }
}
