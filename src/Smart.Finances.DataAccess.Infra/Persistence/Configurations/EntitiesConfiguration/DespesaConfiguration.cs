using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Finances.DataAccess.Core.Entity;

namespace Smart.Finances.DataAccess.Infra.Persistence.Configurations.EntitiesConfiguration
{
    public class DespesaConfiguration: BaseConfiguration<Despesa>, IEntityTypeConfiguration<Despesa>
    {

        public new void Configure(EntityTypeBuilder<Despesa> builder)
        {
            base.Configure(builder);

            builder
                 .Property(p => p.Descricao);
            builder
                .Property(p => p.Valor)
                .IsRequired();

            builder
                .HasOne(d => d.Categoria);

            builder
                .Property(p => p.QuantidadeParcela)
                .IsRequired();

            builder
                .HasOne(d => d.Usuario)
                .WithMany(u => u.Despesas)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(p => p.EhAtivo)
                .IsRequired()
                .HasDefaultValue(true);

            builder
               .Property(p => p.EhRecorrente)
               .IsRequired()
               .HasDefaultValue(true);
        }
    }
}
