using Smart.Finances.DataAccess.Core.Entity;

namespace Smart.Finances.DataAccess.Core.Repositories.Base
{
    public interface IObterPorIdRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity ObterPorId(long sequencialId);
    }
}
