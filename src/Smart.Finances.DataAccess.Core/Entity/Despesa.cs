namespace Smart.Finances.DataAccess.Core.Entity
{
    public class Despesa : BaseEntity
    {
        public string Descricao { get; private set; }
        public double Valor { get; private set; }
        public Categoria Categoria { get; private set; }
        public Usuario Usuario { get; private set; }
        public bool? EhAtivo { get; private set; }
        public int QuantidadeParcela { get; private set; }
        public List<Parcelas> Parcelas { get; private set; }
        public bool? EhRecorrente { get; private set; }

    }
}
