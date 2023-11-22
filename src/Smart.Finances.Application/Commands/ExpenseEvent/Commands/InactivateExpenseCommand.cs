using Smart.Finances.Core.Utils.MessageError;
using System.ComponentModel.DataAnnotations;

namespace Smart.Finances.Application.Commands.ExpenseEvent.Commands
{
    public class InactivateExpenseCommand
    {
        [Required(ErrorMessage = MessageError.ExpenseIdIsRequired)]
        public Guid ExpenseId { get; set; }
    }
}
