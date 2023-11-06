namespace Smart.Finances.DataAccess.Event.Commands.EditarUsuarioCommand
{
    public class EditarUsuarioCommand
    {
        public long Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
    }
}
