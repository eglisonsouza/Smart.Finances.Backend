using Smart.Finances.DataAccess.Core.Entity;

namespace Smart.Finances.DataAccess.Core.Repositories
{
    public interface IDespesaRepository
    {
        Task<IList<Despesa>> ObterDespesaPorMesAsync(int mes, Guid usuarioId);

        Task<IList<Despesa>> ObterDespesaRecorrenteAsync(Guid usuarioId);
    }
}
