namespace Smart.Finances.Core.Common.Consumers
{
    public interface IQueue
    {
        public void CallbackQueue();

        public string GetQueue();
    }
}
