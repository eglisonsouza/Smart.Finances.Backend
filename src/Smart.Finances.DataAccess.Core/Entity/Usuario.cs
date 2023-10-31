namespace Smart.Finances.DataAccess.Core.Entity
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; private set; }
        public string Senha { get; private set; }
        public string Email { get; private set; }
        public IList<DespesaExtra> DespesasExtra { get; private set; }
        public IList<DespesaRecorrente> DespesasRecorrente { get; private set; }

    }
}
