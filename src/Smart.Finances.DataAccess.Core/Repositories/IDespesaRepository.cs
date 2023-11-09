using Smart.Finances.DataAccess.Core.Entity;

namespace Smart.Finances.DataAccess.Core.Repositories
{
    public interface IDespesaRepository
    {
        List<Despesa> ObterDespesaPorMes(int mes, long usuarioId);

        List<Despesa> ObterDespesaRecorrente(long usuarioId);
    }
}
