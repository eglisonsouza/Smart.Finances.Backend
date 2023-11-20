using Smart.Finances.DataAccess.Core.Entity;

namespace Smart.Finances.DataAccess.Event.ViewModels
{
    public class CategoriaViewModel
    {
        public Guid Id { get; set; }
        public string? Descricao { get; set; }
        public bool EhAtivo { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }

        public static CategoriaViewModel FromEntity(Categoria entity)
        {
            return new CategoriaViewModel
            {
                Id = entity.Id,
                Descricao = entity.Descricao,
                EhAtivo = entity.EhAtivo,
                CriadoEm = entity.CriadoEm,
                AtualizadoEm = entity.AtualizadoEm
            };
        }
    }
}
