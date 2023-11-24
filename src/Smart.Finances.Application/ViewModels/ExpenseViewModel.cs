using Smart.Finances.Core.Entity;

namespace Smart.Finances.Application.ViewModels
{
    public class ExpenseViewModel
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public double Value { get; set; }
        public CategoryViewModel? Category { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public int QuantityInstallment { get; set; }
        public bool IsMonthly { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<InstallmentViewModel>? Installments { get; set; }

        public static ExpenseViewModel FromEntity(Expense entity)
        {
            return new ExpenseViewModel
            {
                Id = entity.Id,
                Description = entity.Description,
                Value = entity.Value,
                CategoryId = entity.CategoryId,
                UserId = entity.UserId,
                QuantityInstallment = entity.QuantityInstallment,
                IsMonthly = entity.IsMonthly,
                IsActive = entity.IsActive,
                UpdatedAt = entity.UpdatedAt,
                CreatedAt = entity.CreatedAt,
                Installments = InstallmentViewModel.FromEntity(entity.Installments!),
                Category = BuildCategoy(entity.Category!)
            };
        }

        private static CategoryViewModel? BuildCategoy(Category entity)
        {
            if (entity is null)
                return null;
            return CategoryViewModel.FromEntity(entity);
        }

        public static List<ExpenseViewModel> FromEntity(IEnumerable<Expense> entity)
        {
            return entity.Select(FromEntity).ToList();
        }
    }
}
