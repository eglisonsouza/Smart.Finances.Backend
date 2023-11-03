using Smart.Finances.DataAccess.Core.Entity;
using Smart.Finances.DataAccess.Core.Repositories;
using Smart.Finances.DataAccess.Infra.Persistence.Configurations;

namespace Smart.Finances.DataAccess.Infra.Persistence.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly SqlServerDbContext _context;

        public CategoriaRepository(SqlServerDbContext context)
        {
            _context = context;
        }

        public Categoria Atualizar(Categoria categoria)
        {
            var entity = _context.Update(categoria);
            _context.SaveChanges();
            return entity.Entity;
        }

        public Categoria ObterPorId(long sequencialId)
        {
            var entity = _context.Find<Categoria>(sequencialId)!;
            return entity;
        }
    }
}
