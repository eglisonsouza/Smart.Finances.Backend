using Smart.Finances.DataAccess.Core.Entity;

namespace Smart.Finances.DataAccess.Event.Commands
{
    public class AdicionarCategoriaCommand
    {
        public string Descicao { get; set; }

        public Categoria ToEntity()
        {
            return new Categoria(Descicao);
        }
    }
}
