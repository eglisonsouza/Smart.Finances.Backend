using Smart.Finances.Core.Utils.MessageError;
using System.ComponentModel.DataAnnotations;

namespace Smart.Finances.Application.Queries.ExpenseEvent.Queries
{
    public class GetExpenseMontheyQuery
    {
        [Required(ErrorMessage = MessageError.UserIdIsRequired)]
        public Guid UserId { get; set; }
    }
}
