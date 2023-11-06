using Smart.Finances.DataAccess.Core.Entity;

namespace Smart.Finances.DataAccess.Core.Repositories.Base
{
    public interface IAddRepository<TEntity> where TEntity : BaseEntity
    {
        public TEntity Adicionar(TEntity entity);
    }
}
