using Smart.Finances.DataAccess.Core.Entity;

namespace Smart.Finances.DataAccess.Core.Repositories.Base
{
    public interface IObterTodosRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> ObterTodosAsync();
    }
}
