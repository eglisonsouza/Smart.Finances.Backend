using Smart.Finances.DataAccess.Core.Entity;

namespace Smart.Finances.DataAccess.Core.Repositories
{
    public interface IDespesaRepository
    {
        Task<IList<Despesa>> ObterDespesaPorMesAsync(int mes, long usuarioId);

        Task<IList<Despesa>> ObterDespesaRecorrenteAsync(long usuarioId);
    }
}
