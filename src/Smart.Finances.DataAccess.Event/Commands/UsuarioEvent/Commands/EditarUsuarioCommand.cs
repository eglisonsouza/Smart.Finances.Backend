namespace Smart.Finances.DataAccess.Event.Commands.UsuarioEvent.Commands
{
    public class EditarUsuarioCommand
    {
        public long Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
    }
}
