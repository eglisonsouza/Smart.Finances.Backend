using Smart.Finances.Core.Entity;

namespace Smart.Finances.Application.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public static UserViewModel FromEntity(User entity)
        {
            return new UserViewModel
            {
                Id = entity.Id,
                Email = entity.Email,
                Name = entity.Name,
            };
        }
    }
}
