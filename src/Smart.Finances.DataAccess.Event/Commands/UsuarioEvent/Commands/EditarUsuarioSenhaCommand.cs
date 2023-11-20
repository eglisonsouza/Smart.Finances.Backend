namespace Smart.Finances.DataAccess.Event.Commands.UsuarioEvent.Commands
{
    public class EditarUsuarioSenhaCommand
    {
        public Guid Id { get; set; }
        public string Senha { get; set; }
    }
}
