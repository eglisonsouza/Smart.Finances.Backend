using Microsoft.EntityFrameworkCore;
using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Repositories.Base;
using Smart.Finances.Infra.Persistence.Configurations;

namespace Smart.Finances.Infra.Persistence.Repositories
{
    public class GenericRepository<TEntity> :
        IAddRepository<TEntity>,
        IAtualizaRepository<TEntity>,
        IObterPorIdRepository<TEntity>,
        IObterTodosRepository<TEntity>,
        IAddVariosRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly SqlServerDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(SqlServerDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> AdicionarAsync(TEntity entity)
        {
            var result = await _dbSet.AddAsync(entity);
            _context.SaveChanges();
            return result.Entity;
        }

        public async Task<int> AdicionarVariosAsync(List<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return _context.SaveChanges();
        }

        public async Task<TEntity> AtualizarAsync(TEntity categoria)
        {
            var entity = _dbSet.Update(categoria);
            _context.SaveChanges();
            return entity.Entity;
        }

        public async Task<TEntity?> ObterPorIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<TEntity>> ObterTodosAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
