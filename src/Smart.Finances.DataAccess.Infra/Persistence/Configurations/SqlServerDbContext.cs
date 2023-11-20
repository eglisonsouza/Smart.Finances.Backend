using Microsoft.EntityFrameworkCore;
using Smart.Finances.Core.Entity;

namespace Smart.Finances.Infra.Persistence.Configurations
{
    public class SqlServerDbContext : DbContext
    {
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Parcelas> Parcelas { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Despesa> Despesa { get; set; }

        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlServerDbContext).Assembly);
        }
    }
}
