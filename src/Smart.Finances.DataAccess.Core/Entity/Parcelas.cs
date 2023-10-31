namespace Smart.Finances.DataAccess.Core.Entity
{
    public class Parcelas : BaseEntity
    {
        public DateTime Vencimento { get; private set; }
        public int Numero { get; private set; }
        public string? Descricao { get; private set; }
        public DespesaExtra DespesaExtra { get; private set; }
        public DateTime? PagamentoEm { get; private set; }
    }
}