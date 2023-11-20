using Microsoft.EntityFrameworkCore;
using Smart.Finances.DataAccess.Core.Entity;
using Smart.Finances.DataAccess.Core.Repositories;
using Smart.Finances.DataAccess.Infra.Persistence.Configurations;

namespace Smart.Finances.DataAccess.Infra.Persistence.Repositories
{
    public class DespesaRepository : IDespesaRepository
    {
        private readonly SqlServerDbContext _context;

        public DespesaRepository(SqlServerDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Despesa>> ObterDespesaPorMesAsync(int mes, Guid usuarioId)
        {
            return await _context.Despesa
                .Include(d => d.Categoria)
                .Include(d => d.Parcelas.Where(p => p.Vencimento.Month.Equals(mes)))
                .Where(d => d.UsuarioId.Equals(usuarioId) && d.EhRecorrente.Equals(false)).ToListAsync();
        }

        public async Task<IList<Despesa>> ObterDespesaRecorrenteAsync(Guid usuarioId)
        {
            return await _context.Despesa
                .Include(d => d.Categoria)
                .Include(d => d.Parcelas)
                .Where(d => d.UsuarioId.Equals(usuarioId) && d.EhRecorrente.Equals(true) && d.EhAtivo.Equals(true)).ToListAsync();
        }
    }
}
