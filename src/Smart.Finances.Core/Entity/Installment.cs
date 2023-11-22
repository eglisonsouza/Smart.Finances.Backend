using System.Globalization;

namespace Smart.Finances.Core.Entity
{
    public class Installment : BaseEntity
    {
        public DateTime DueDate { get; private set; }
        public int Number { get; private set; }
        public string? Description { get; private set; }
        public DateTime? PaymentIn { get; private set; }
        public double Value { get; private set; }
        public Guid ExpenseId { get; private set; }
        public Expense? Expense { get; private set; }

        public Installment(DateTime DueDate, int number, string? description, double value, Guid expenseId) : base()
        {
            this.DueDate = DueDate;
            Number = number;
            Description = description;
            Value = value;
            ExpenseId = expenseId;
        }

        public void Pay()
        {
            if (PaymentIn is not null)
            {
                throw new Exception($"Parcela já foi paga em {PaymentIn}");
            }
            PaymentIn = DateTime.Now;
        }

        public string GenerateMessage()
        {
            return @$"Olá! 
Você pagou a parcela {Number} da despesa {Expense?.Description} no valor de {Value.ToString("C2", CultureInfo.CurrentCulture)}.";
        }
    }
}