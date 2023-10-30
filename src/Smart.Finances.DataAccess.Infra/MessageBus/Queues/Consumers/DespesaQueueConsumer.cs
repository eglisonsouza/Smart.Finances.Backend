using Smart.Finances.DataAccess.Core.Common.Consumers;

namespace Smart.Finances.DataAccess.Infra.MessageBus.Queues.Consumers
{
    public interface IDespesaQueueConsumer : IQueue { }

    public class DespesaQueueConsumer : IDespesaQueueConsumer
    {
        private const string DESPESA_QUEUE = "DesquesaCadastro";

        public void CallbackQueue()
        {
            throw new NotImplementedException();
        }

        public string GetQueue()
        {
            return DESPESA_QUEUE;
        }
    }
}
