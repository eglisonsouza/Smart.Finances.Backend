using Microsoft.EntityFrameworkCore;
using Smart.Finances.DataAccess.Core.Entity;
using Smart.Finances.DataAccess.Core.Repositories.Base;
using Smart.Finances.DataAccess.Infra.Persistence.Configurations;

namespace Smart.Finances.DataAccess.Infra.Persistence.Repositories
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

        public TEntity Adicionar(TEntity entity)
        {
            var result = _dbSet.Add(entity);
            _context.SaveChanges();
            return result.Entity;
        }

        public int AdicionarVarios(List<TEntity> entities)
        {
            _dbSet.AddRange(entities);
            return _context.SaveChanges();
        }

        public TEntity Atualizar(TEntity categoria)
        {
            var entity = _dbSet.Update(categoria);
            _context.SaveChanges();
            return entity.Entity;
        }

        public TEntity ObterPorId(long sequencialId)
        {
            var entity = _dbSet.Find(sequencialId)!;
            return entity;
        }

        public IList<TEntity> ObterTodos()
        {
            return _dbSet.ToList();
        }
    }
}
