using Smart.Finances.DataAccess.Core.Entity;

namespace Smart.Finances.DataAccess.Core.Repositories.Base
{
    public interface IAddVariosRepository<TEntity> where TEntity : BaseEntity
    {
        public int AdicionarVarios(List<TEntity> entities);
    }
}
