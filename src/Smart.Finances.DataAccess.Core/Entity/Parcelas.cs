namespace Smart.Finances.DataAccess.Core.Entity
{
    public class Parcelas : BaseEntity
    {
        public DateTime Vencimento { get; private set; }
        public int Numero { get; private set; }
        public string? Descricao { get; private set; }
        public DateTime? PagamentoEm { get; private set; }
        public double ValorParcela { get; private set; }
        public Guid DespesaId { get; private set; }
        public Despesa? Despesa { get; private set; }

        public Parcelas(DateTime vencimento, int numero, string? descricao, double valorParcela, Guid despesaId) : base()
        {
            Vencimento = vencimento;
            Numero = numero;
            Descricao = descricao;
            ValorParcela = valorParcela;
            DespesaId = despesaId;
        }

        public void Pagar()
        {
            if (PagamentoEm is not null)
            {
                throw new Exception($"Parcela já foi paga em {PagamentoEm}");
            }
            PagamentoEm = DateTime.Now;
        }
    }
}