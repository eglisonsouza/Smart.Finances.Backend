using Smart.Finances.Core.Entity;

namespace Smart.Finances.Event.Commands.CategoriaEvent.Commands
{
    public class AdicionarCategoriaCommand
    {
        public string? Descricao { get; set; }

        public Categoria ToEntity()
        {
            return new Categoria(Descricao!);
        }
    }
}
