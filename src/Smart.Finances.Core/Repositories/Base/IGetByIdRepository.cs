using Smart.Finances.Core.Entity;

namespace Smart.Finances.Core.Repositories.Base
{
    public interface IGetByIdRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?> GetByIdAsync(Guid? id);
    }
}
