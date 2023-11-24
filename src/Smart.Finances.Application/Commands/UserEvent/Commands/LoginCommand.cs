using Smart.Finances.Core.Utils.MessageError;
using System.ComponentModel.DataAnnotations;

namespace Smart.Finances.Application.Commands.UserEvent.Commands
{
    public class LoginCommand
    {
        [Required(ErrorMessage = MessageError.PasswordIsRequired)]
        public string? Password { get; set; }

        [Required(ErrorMessage = MessageError.UserEmailIsRequired)]
        public string? Email { get; set; }
    }
}
