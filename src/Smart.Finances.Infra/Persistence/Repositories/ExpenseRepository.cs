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

        public Task<List<Expense>> GetByMonthAsync(int month, Guid userId)
        {
            return _context.Expense
                .Include(d => d.Category)
                .Include(d => d.Installments!.Where(p => p.DueDate.Month.Equals(month)))
                .Where(d => d.UserId.Equals(userId) && d.IsMonthly.Equals(false) && d.IsActive.Equals(true)).ToListAsync();
        }
        public Task<List<Expense>> GetExpenseMontheyAsync(Guid userId)
        {
            return _context.Expense
                .Include(d => d.Category)
                .Include(d => d.Installments)
                .Where(d => d.UserId.Equals(userId) && d.IsMonthly.Equals(true) && d.IsActive.Equals(true))
                .ToListAsync();
        }
    }
}
