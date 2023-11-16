using Smart.Finances.DataAccess.Core.Entity;

namespace Smart.Finances.DataAccess.Event.ViewModels
{
    public class DespesaViewModel
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public CategoriaViewModel Categoria { get; set; }
        public long CategoriaId { get; set; }
        public long UsuarioId { get; set; }
        public int QuantidadeParcela { get; set; }
        public bool EhRecorrente { get; set; }
        public bool EhAtivo { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public List<ParcelasViewModel> Parcelas { get; set; }

        public static DespesaViewModel FromEntity(Despesa entity)
        {
            var despesaViewModel = new DespesaViewModel
            {
                Id = entity.Id,
                Descricao = entity.Descricao,
                Valor = entity.Valor,
                CategoriaId = entity.CategoriaId,
                UsuarioId = entity.UsuarioId,
                QuantidadeParcela = entity.QuantidadeParcela,
                EhRecorrente = entity.EhRecorrente,
                EhAtivo = entity.EhAtivo,
                AtualizadoEm = entity.AtualizadoEm,
                CriadoEm = entity.CriadoEm,
                Parcelas = ParcelasViewModel.FromEntity(entity.Parcelas)
            };
            
            if (entity.Categoria is not null) despesaViewModel.Categoria = CategoriaViewModel.FromEntity(entity.Categoria);
            
            return despesaViewModel;
        }

        public static List<DespesaViewModel> FromEntity(IEnumerable<Despesa> entity)
        {
            return entity.Select(e => FromEntity(e)).ToList();
        }

    }
}
