namespace Smart.Finances.DataAccess.Core.Entity
{
    public class Despesa : BaseEntity
    {
        public string Descricao { get; private set; }
        public double Valor { get; private set; }
        public Categoria Categoria { get; private set; }
        public Usuario Usuario { get; private set; }
    }
}
