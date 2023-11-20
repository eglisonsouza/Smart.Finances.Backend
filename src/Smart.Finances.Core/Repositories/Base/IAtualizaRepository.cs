using Smart.Finances.Core.Entity;

namespace Smart.Finances.Core.Repositories.Base
{
    public interface IAtualizaRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> AtualizarAsync(TEntity categoria);
    }
}
