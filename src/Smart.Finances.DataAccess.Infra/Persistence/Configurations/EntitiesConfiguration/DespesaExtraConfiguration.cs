using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Finances.DataAccess.Core.Entity;

namespace Smart.Finances.DataAccess.Infra.Persistence.Configurations.EntitiesConfiguration
{
    public class DespesaExtraConfiguration : IEntityTypeConfiguration<DespesaExtra>
    {

        public void Configure(EntityTypeBuilder<DespesaExtra> builder)
        {
            builder
                .Property(p => p.QuantidadeParcela)
                .IsRequired();

            builder
                .HasOne(d => d.Usuario)
                .WithMany(u => u.DespesasExtra)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(d => d.Parcelas)
                .WithOne(p => p.DespesaExtra)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
