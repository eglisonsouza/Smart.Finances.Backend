using Smart.Finances.Core.Utils.MessageError;
using System.ComponentModel.DataAnnotations;

namespace Smart.Finances.Application.Commands.UserEvent.Commands
{
    public class UpdateUserCommand
    {
        [Required(ErrorMessage = MessageError.NameIsRequired)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = MessageError.NameIsRequired)]
        public string? Name { get; set; }

        [Required(ErrorMessage = MessageError.UserEmailIsRequired)]
        public string? Email { get; set; }
    }
}
