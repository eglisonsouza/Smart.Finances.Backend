using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Finances.DataAccess.Core.Entity;

namespace Smart.Finances.DataAccess.Infra.Persistence.Configurations.EntitiesConfiguration
{
    public class UsuarioConfiguration : BaseConfiguration<Usuario>, IEntityTypeConfiguration<Usuario>
    {
        public new void Configure(EntityTypeBuilder<Usuario> builder)
        {
            base.Configure(builder);

            builder
                .Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(p => p.Senha)
                .IsRequired();
            builder
                .Property(p => p.Email)
                .IsRequired();

            builder
                .HasMany(u => u.Despesas)
                .WithOne(d => d.Usuario)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
