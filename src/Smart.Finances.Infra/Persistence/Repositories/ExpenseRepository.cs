using Microsoft.EntityFrameworkCore;
using Smart.Finances.Core.Entity;
using Smart.Finances.Core.Repositories;
using Smart.Finances.Infra.Persistence.Configurations;

namespace Smart.Finances.Infra.Persistence.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly SqlServerDbContext _context;

        public ExpenseRepository(SqlServerDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Expense>> GetByMonthAsync(int month, Guid userId)
        {
            return await _context.Expense
                .Include(d => d.Category)
                .Include(d => d.Installments!.Where(p => p.DueDate.Month.Equals(month)))
                .Where(d => IsNotMonthlyByUser(userId, d)).ToListAsync();
        }

        private static bool IsNotMonthlyByUser(Guid userId, Expense d)
        {
            return d.UserId.Equals(userId) && d.IsNotMonthlyAndActive();
        }

        public async Task<IList<Expense>> GetExpenseMontheyAsync(Guid userId)
        {
            return await _context.Expense
                .Include(d => d.Category)
                .Include(d => d.Installments)
                .Where(d => IsMonthlyByUser(userId, d)).ToListAsync();
        }

        private static bool IsMonthlyByUser(Guid userId, Expense d)
        {
            return d.UserId.Equals(userId) && d.IsMonthlyAndActive();
        }
    }
}
