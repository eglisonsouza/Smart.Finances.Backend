using Smart.Finances.Core.Entity;

namespace Smart.Finances.Core.Repositories.Base
{
    public interface IAddRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> AdicionarAsync(TEntity entity);
    }
}
