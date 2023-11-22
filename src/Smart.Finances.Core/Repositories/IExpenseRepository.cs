using Smart.Finances.Core.Entity;

namespace Smart.Finances.Core.Repositories
{
    public interface IExpenseRepository
    {
        Task<IList<Expense>> GetByMonthAsync(int month, Guid userId);

        Task<IList<Expense>> GetExpenseMontheyAsync(Guid userId);
    }
}
