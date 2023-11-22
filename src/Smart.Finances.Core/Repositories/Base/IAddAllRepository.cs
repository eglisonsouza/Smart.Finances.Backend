using Smart.Finances.Core.Entity;

namespace Smart.Finances.Core.Repositories.Base
{
    public interface IAddAllRepository<TEntity> where TEntity : BaseEntity
    {
        Task<int> AddAllAsync(List<TEntity> entities);
    }
}
