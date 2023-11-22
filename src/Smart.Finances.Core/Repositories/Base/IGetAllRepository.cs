using Smart.Finances.Core.Entity;

namespace Smart.Finances.Core.Repositories.Base
{
    public interface IGetAllRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAllAsync();
    }
}
