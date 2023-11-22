using Smart.Finances.Core.Entity;

namespace Smart.Finances.Core.Repositories.Base
{
    public interface IUpdateRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Update(TEntity categoria);
    }
}
