using Smart.Finances.Core.Entity;

namespace Smart.Finances.Event.ViewModels
{
    public class ParcelasViewModel
    {
        public Guid Id { get; set; }
        public DateTime Vencimento { get; set; }
        public int NumeroParcela { get; set; }
        public string Descricao { get; set; }
        public DateTime PagamentoEm { get; set; }

        public static List<ParcelasViewModel> FromEntity(List<Parcelas> parcelas)
        {
            return parcelas.Select(p => FromEntity(p)).ToList();
        }

        public static ParcelasViewModel FromEntity(Parcelas parcela)
        {
            return new ParcelasViewModel
            {
                Id = parcela.Id,
                Vencimento = parcela.Vencimento,
                NumeroParcela = parcela.Numero,
                Descricao = parcela.Descricao!,
                PagamentoEm = parcela.PagamentoEm ?? DateTime.MinValue
            };
        }
    }
}