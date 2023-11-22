using System.Globalization;

namespace Smart.Finances.Core.Entity
{
    public class Expense : BaseEntity
    {
        public string Description { get; private set; }
        public double Value { get; private set; }
        public Category? Category { get; private set; }
        public Guid CategoryId { get; private set; }
        public User? User { get; private set; }
        public Guid UserId { get; private set; }
        public bool IsActive { get; private set; }
        public int QuantityInstallment { get; private set; }
        public List<Installment>? Installments { get; private set; }
        public bool IsMonthly { get; private set; }

        public Expense(string description, double value, int quantityInstallment, bool isMonthly, Guid categoryId, Guid userId) : base()
        {
            Description = description;
            Value = value;
            IsActive = true;
            QuantityInstallment = quantityInstallment;
            IsMonthly = isMonthly;
            CategoryId = categoryId;
            UserId = userId;
        }

        public void GenerateInstallment(DateTime firstDue)
        {
            var valueInstallment = CalcValueInstallment();

            Installments = new List<Installment>();

            for (int i = 0; i < QuantityInstallment; i++)
            {
                Installments.Add(new Installment(
                    DueDate: firstDue.AddMonths(1 * i),
                    number: (1 + i),
                    description: $"{(i + 1)}/{QuantityInstallment}",
                    value: valueInstallment,
                    expenseId: Id));
            }
        }

        private double CalcValueInstallment()
        {
            return Value / QuantityInstallment;
        }

        public void SetCategoria(Category category)
        {
            Category = category;
        }

        public void SetUsuario(User user)
        {
            User = user;
        }

        public void Inativate()
        {
            IsActive = false;
        }

        public string GenerateMessage()
        {
            return @$"Olá!

Você cadastrou uma nova despesa no valor de {Value.ToString("C2", CultureInfo.CurrentCulture)} com a descrição {Description}.
A primeira parcela vence em {GetFistDueDate()}.
A última parcela vence em {GetLastDueDate()}.
O valor de cada parcela é de R${GetValueInstallment()}.

Obrigado por utilizar o Smart Finances!";
        }

        private double GetValueInstallment()
        {
            if (!IsMonthly)
                return Installments![0].Value;
            return Value;
        }

        private string GetFistDueDate()
        {
            if (!IsMonthly)
                return Installments![0].DueDate.ToShortDateString();

            return string.Empty;
        }

        private string GetLastDueDate()
        {
            if (!IsMonthly)
                return Installments![QuantityInstallment - 1].DueDate.AddMonths(1).ToShortDateString();

            return string.Empty;
        }

        public bool IsMonthlyAndActive()
        {
            return IsMonthly.Equals(true) && IsActive.Equals(true);
        }

        public bool IsNotMonthlyAndActive()
        {
            return IsMonthly.Equals(false) && IsActive.Equals(true);
        }
    }
}
