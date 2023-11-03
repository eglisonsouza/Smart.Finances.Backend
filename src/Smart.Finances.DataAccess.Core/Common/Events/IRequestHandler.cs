namespace Smart.Finances.DataAccess.Core.Common.Events
{
    public interface IRequestHandler<in TRequest>
    {
        Task Handle(TRequest request);
    }

    public interface IRequestHandler<in TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
}
