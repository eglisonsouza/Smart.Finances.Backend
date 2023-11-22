using Smart.Finances.Core.Entity;

namespace Smart.Finances.Application.ViewModels
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public static CategoryViewModel FromEntity(Category entity)
        {
            return new CategoryViewModel
            {
                Id = entity.Id,
                Description = entity.Description,
                IsActive = entity.IsActive,
                CreateAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }

        public static List<CategoryViewModel> FromEntity(List<Category> entities)
        {
            return entities.Select(CategoryViewModel.FromEntity).ToList();
        }
    }
}
