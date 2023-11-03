namespace Smart.Finances.DataAccess.Event.Commands.EditarCategoriaCommand
{
    public class EditarCategoriaCommand
    {
        public long Id { get; set; }
        public string? Descricao { get; set; }
        public bool EhAtivo { get; set; }
    }
}
