namespace Smart.Finances.Event.Commands.CategoriaEvent.Commands
{
    public class EditarCategoriaCommand
    {
        public Guid Id { get; set; }
        public string? Descricao { get; set; }
        public bool EhAtivo { get; set; }
    }
}
