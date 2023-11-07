using Smart.Finances.DataAccess.Core.Entity;

namespace Smart.Finances.DataAccess.Event.ViewModels
{
    public class ParcelasViewModel
    {
        public long Id { get; set; }
        public DateTime Vencimento { get; set; }
        public int NumeroParcela { get; set; }
        public string Descricao { get; set; }
        public DateTime PagamentoEm { get; set; }

        public static List<ParcelasViewModel> FromEntity(List<Parcelas> parcelas)
        {
            return parcelas.Select(p => new ParcelasViewModel
            {
                Id = p.Id,
                Vencimento = p.Vencimento,
                NumeroParcela = p.Numero,
                Descricao = p.Descricao!,
                PagamentoEm = p.PagamentoEm ?? DateTime.MinValue
            }).ToList();
        }
    }
}