using Smart.Finances.Core.Utils.MessageError;
using System.ComponentModel.DataAnnotations;

namespace Smart.Finances.Application.Commands.InstallmentEvent.Commands
{
    public class PayInstallmentCommand
    {
        [Required(ErrorMessage = MessageError.InstallmentIdIsRequired)]
        public Guid InstallmentId { get; set; }

        [Required(ErrorMessage = MessageError.UserEmailIsRequired)]
        public string? UserEmail { get; set; }
    }
}
