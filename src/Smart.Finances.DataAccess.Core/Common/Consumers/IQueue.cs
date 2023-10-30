namespace Smart.Finances.DataAccess.Core.Common.Consumers
{
    public interface IQueue
    {
        public void CallbackQueue();

        public string GetQueue();
    }
}
