using Smart.Finances.Core.Utils.MessageError;
using System.ComponentModel.DataAnnotations;

namespace Smart.Finances.Application.Commands.UserEvent.Commands
{
    public class UpdatePasswordCommand
    {
        [Required(ErrorMessage = MessageError.UserIdIsRequired)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = MessageError.PasswordIsRequired)]
        public string? Password { get; set; }
    }
}
