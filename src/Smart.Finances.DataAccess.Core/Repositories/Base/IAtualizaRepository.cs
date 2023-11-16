using Smart.Finances.DataAccess.Core.Entity;

namespace Smart.Finances.DataAccess.Core.Repositories.Base
{
    public interface IAtualizaRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> AtualizarAsync(TEntity categoria);
    }
}
