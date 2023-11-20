using Smart.Finances.Core.Entity;

namespace Smart.Finances.Core.Repositories
{
    public interface IDespesaRepository
    {
        Task<IList<Despesa>> ObterDespesaPorMesAsync(int mes, Guid usuarioId);

        Task<IList<Despesa>> ObterDespesaRecorrenteAsync(Guid usuarioId);
    }
}
