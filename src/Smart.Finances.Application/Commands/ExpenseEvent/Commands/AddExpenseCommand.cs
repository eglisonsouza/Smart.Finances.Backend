using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Utils.MessageError;
using System.ComponentModel.DataAnnotations;

namespace Smart.Finances.Application.Commands.ExpenseEvent.Commands
{
    public class AddExpenseCommand
    {
        [Required(ErrorMessage = MessageError.DescriptionIsRequired)]
        public string? Description { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = MessageError.ValueRange)]
        public double Value { get; set; }

        [Required(ErrorMessage = MessageError.CategoryIdIsRequired)]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = MessageError.UserIdIsRequired)]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = MessageError.UserEmailIsRequired)]
        public string? EmailUser { get; set; }

        [Required]
        [Range(minimum: 0, maximum: int.MaxValue, ErrorMessage = MessageError.QuantityRange)]
        public int QuantityInstallment { get; set; }

        [Required(ErrorMessage = MessageError.IsMonthyRequired)]
        public bool IsMonthly { get; set; }

        [Required(ErrorMessage = MessageError.FirstDueIsRequired)]
        public DateTime FirstDue { get; set; }

        public Expense ToEntity()
        {
            return new Expense(Description!, Value, QuantityInstallment, IsMonthly, CategoryId, UserId);
        }
    }
}
