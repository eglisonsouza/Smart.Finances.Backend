using Smart.Finances.Core.Entity;

namespace Smart.Finances.Core.Repositories.Base
{
    public interface IAddVariosRepository<TEntity> where TEntity : BaseEntity
    {
        Task<int> AdicionarVariosAsync(List<TEntity> entities);
    }
}
