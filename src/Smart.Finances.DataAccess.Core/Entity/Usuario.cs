namespace Smart.Finances.DataAccess.Core.Entity
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; private set; }
        public string Senha { get; private set; }
        public string Email { get; private set; }
        public IList<Despesa>? Despesas { get; private set; }

        public Usuario(string nome, string senha, string email) : base()
        {
            Nome = nome;
            Senha = senha;
            Email = email;
        }

        public void AtualizarPerfil(string nomeCompleto, string email)
        {
            Atualizar();
            Nome = nomeCompleto;
            Email = email;
        }

        public void AtualizarSenha(string senha)
        {
            Atualizar();
            Senha = senha;
        }
    }
}
