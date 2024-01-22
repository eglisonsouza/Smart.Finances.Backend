using Smart.Finances.Core.Model.Args;
using Smart.Finances.Core.Model.UI;
using Smart.Finances.Infra.MessageBus.Setup;

namespace Smart.Finances.Infra.MessageBus.Queues.Publishers
{
    public interface INotificationQueuePublisher
    {
        void Publish(EmailArgs email);
    }
    public class NotificationQueuePublisher : RabbitMqPublisher, INotificationQueuePublisher
    {
        private const string NotificationQueue = "notification";

        public NotificationQueuePublisher(ApiSettings apiSettings) : base(apiSettings)
        {
        }

        public void Publish(EmailArgs email)
        {
            base.Publish(NotificationQueue, email.ToBytes());
        }
    }
}
