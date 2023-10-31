namespace Smart.Finances.DataAccess.Core.Entity
{
    public class DespesaExtra : Despesa
    {
        public int QuantidadeParcela { get; private set; }
        public List<Parcelas> Parcelas { get; private set; }
    }
}
