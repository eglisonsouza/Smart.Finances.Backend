using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Utils.MessageError;
using System.ComponentModel.DataAnnotations;

namespace Smart.Finances.Application.Commands.CategoryEvent.Commands
{
    public class AddCategoryCommand
    {
        [Required(ErrorMessage = MessageError.DescriptionIsRequired)]
        public string? Description { get; set; }

        public Category ToEntity()
        {
            return new Category(Description!);
        }
    }
}
