using Smart.Finances.Core.Entity;

namespace Smart.Finances.Core.Repositories.Base
{
    public interface IObterPorIdRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> ObterPorIdAsync(Guid id);
    }
}
