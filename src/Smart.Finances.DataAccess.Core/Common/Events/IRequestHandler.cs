namespace Smart.Finances.DataAccess.Core.Common.Events
{
    public interface IRequestHandler<TResponse>
    {
        Task<TResponse> Handle();
    }

    public interface IRequestHandler<in TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
}
