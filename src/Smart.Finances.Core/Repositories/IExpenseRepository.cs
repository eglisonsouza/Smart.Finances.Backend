using Smart.Finances.Core.Entity;

namespace Smart.Finances.Core.Repositories
{
    public interface IExpenseRepository
    {
        Task<List<Expense>> GetByMonthAsync(int month, Guid userId);

        Task<List<Expense>> GetExpenseMontheyAsync(Guid userId);
    }
}
