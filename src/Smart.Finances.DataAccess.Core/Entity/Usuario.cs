namespace Smart.Finances.DataAccess.Core.Entity
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; private set; }
        public string Senha { get; private set; }
        public string Email { get; private set; }
        public IList<Despesa> Despesas { get; private set; }
    }
}
