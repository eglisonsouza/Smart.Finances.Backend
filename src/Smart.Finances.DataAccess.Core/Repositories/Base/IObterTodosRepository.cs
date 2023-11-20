using Smart.Finances.Core.Entity;

namespace Smart.Finances.Core.Repositories.Base
{
    public interface IObterTodosRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> ObterTodosAsync();
    }
}
