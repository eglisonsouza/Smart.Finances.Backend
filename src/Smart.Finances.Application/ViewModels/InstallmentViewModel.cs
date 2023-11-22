using Smart.Finances.Core.Entity;

namespace Smart.Finances.Application.ViewModels
{
    public class InstallmentViewModel
    {
        public Guid Id { get; set; }
        public DateTime DueDate { get; set; }
        public int Number { get; set; }
        public string? Description { get; set; }
        public DateTime PaymentIn { get; set; }

        public static List<InstallmentViewModel> FromEntity(List<Installment> installments)
        {
            return installments.Select(FromEntity).ToList();
        }

        public static InstallmentViewModel FromEntity(Installment installment)
        {
            return new InstallmentViewModel
            {
                Id = installment.Id,
                DueDate = installment.DueDate,
                Number = installment.Number,
                Description = installment.Description!,
                PaymentIn = installment.PaymentIn ?? DateTime.MinValue
            };
        }
    }
}