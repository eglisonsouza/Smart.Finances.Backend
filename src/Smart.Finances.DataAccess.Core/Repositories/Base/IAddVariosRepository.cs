using Smart.Finances.DataAccess.Core.Entity;

namespace Smart.Finances.DataAccess.Core.Repositories.Base
{
    public interface IAddVariosRepository<TEntity> where TEntity : BaseEntity
    {
        Task<int> AdicionarVariosAsync(List<TEntity> entities);
    }
}
