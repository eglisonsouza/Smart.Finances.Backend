using Smart.Finances.Core.Utils.MessageError;
using System.ComponentModel.DataAnnotations;

namespace Smart.Finances.Application.Commands.CategoryEvent.Commands
{
    public class EditCategoryCommand
    {
        [Required(ErrorMessage = MessageError.IdIsRequired)]
        public Guid Id { get; set; }
        [Required(ErrorMessage = MessageError.DescriptionIsRequired)]
        public string? Description { get; set; }
    }
}
