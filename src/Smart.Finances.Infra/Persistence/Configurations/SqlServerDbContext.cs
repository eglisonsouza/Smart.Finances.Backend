using Microsoft.EntityFrameworkCore;
using Smart.Finances.Core.Entity;

namespace Smart.Finances.Infra.Persistence.Configurations
{
    public class SqlServerDbContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Installment> Installment { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Expense> Expense { get; set; }

        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlServerDbContext).Assembly);
        }
    }
}
