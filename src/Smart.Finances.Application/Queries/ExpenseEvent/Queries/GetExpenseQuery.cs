using Smart.Finances.Core.Utils.MessageError;
using System.ComponentModel.DataAnnotations;

namespace Smart.Finances.Application.Queries.ExpenseEvent.Queries
{
    public class GetExpenseQuery
    {
        [Required(ErrorMessage = MessageError.ReferenceMonthIsRequired)]
        public int ReferenceMonth { get; set; }

        [Required(ErrorMessage = MessageError.UserIdIsRequired)]
        public Guid UserId { get; set; }
    }
}
