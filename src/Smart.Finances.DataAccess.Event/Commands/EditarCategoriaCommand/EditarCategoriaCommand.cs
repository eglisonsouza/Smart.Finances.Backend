using Smart.Finances.DataAccess.Core.Entity;

namespace Smart.Finances.DataAccess.Event.Commands.EditarCategoriaCommand
{
    public class EditarCategoriaCommand
    {
        public Guid Id { get; set; }
        public long SequencialId { get; set; }
        public string? Descricao { get; set; }
        public bool EhAtivo { get; set; }
    }
}
