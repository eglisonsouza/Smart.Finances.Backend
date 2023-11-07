using Smart.Finances.DataAccess.Core.Entity;

namespace Smart.Finances.DataAccess.Event.Commands.DespesaEvent.Commands
{
    public class CadastrarDespesaCommand
    {
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public long CategoriaId { get; set; }
        public long UsuarioId { get; set; }
        public int QuantidadeParcela { get; set; }
        public bool EhRecorrente { get; set; }
        public DateTime PrimeiroVencimento { get; set; }

        public Despesa ToEntity()
        {
            return new Despesa(Descricao, Valor, QuantidadeParcela, EhRecorrente, CategoriaId, UsuarioId);
        }
    }
}
