using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Utils.MessageError;
using System.ComponentModel.DataAnnotations;

namespace Smart.Finances.Application.Commands.UserEvent.Commands
{
    public class AddUserCommand
    {
        [Required(ErrorMessage = MessageError.NameIsRequired)]
        public string? Name { get; set; }

        [Required(ErrorMessage = MessageError.PasswordIsRequired)]
        public string? Password { get; set; }

        [Required(ErrorMessage = MessageError.UserEmailIsRequired)]
        public string? Email { get; set; }

        public User ToEntity()
        {
            return new User(Name!, Password!, Email!);
        }

        public void SetSenhaHash(string password)
        {
            Password = password;
        }
    }
}
