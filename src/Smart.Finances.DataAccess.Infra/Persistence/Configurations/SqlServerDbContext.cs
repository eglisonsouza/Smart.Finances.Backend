using Microsoft.EntityFrameworkCore;

namespace Smart.Finances.DataAccess.Infra.Persistence.Configurations
{
    public class SqlServerDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlServerDbContext).Assembly);
        }
    }
}
