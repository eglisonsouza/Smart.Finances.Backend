using Smart.Finances.Core.Common.Consumers;

namespace Smart.Finances.Infra.MessageBus.Queues.Consumers
{
    public interface IExpenseQueueConsumer : IQueue { }

    public class ExpenseQueueConsumer : IExpenseQueueConsumer
    {
        private const string ExpenseQueue = "AddExpense";

        public void CallbackQueue()
        {
            throw new NotImplementedException();
        }

        public string GetQueue()
        {
            return ExpenseQueue;
        }
    }
}
