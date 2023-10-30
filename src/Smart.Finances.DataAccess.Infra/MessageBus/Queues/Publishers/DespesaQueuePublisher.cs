using Smart.Finances.DataAccess.Infra.MessageBus.Setup;
using System.Text;

namespace Smart.Finances.DataAccess.Infra.MessageBus.Queues.Publishers
{
    public interface IDespesaQueuePublisher
    {
        void Publish();
    }
    public class DespesaQueuePublisher : RabbitMqPublisher, IDespesaQueuePublisher
    {
        private const string DESPESA_QUEUE = "DesquesaCadastroRetorno";

        public void Publish()
        {
            //TO DO - Base
            base.Publish(DESPESA_QUEUE, Encoding.UTF8.GetBytes(string.Empty));
            throw new NotImplementedException();
        }
    }
}
