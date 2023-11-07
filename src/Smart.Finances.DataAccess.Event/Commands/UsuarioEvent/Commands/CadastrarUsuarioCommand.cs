using Smart.Finances.DataAccess.Core.Entity;

namespace Smart.Finances.DataAccess.Event.Commands.UsuarioEvent.Commands
{
    public class CadastrarUsuarioCommand
    {
        public string NomeCompleto { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }

        public Usuario ToEntity()
        {
            return new Usuario(NomeCompleto, Senha, Email);
        }

        public void SetSenhaHash(string senha)
        {
            Senha = senha;
        }
    }
}
