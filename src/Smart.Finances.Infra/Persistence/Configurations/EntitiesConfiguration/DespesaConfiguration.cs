using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Finances.Core.Entity;

namespace Smart.Finances.Infra.Persistence.Configurations.EntitiesConfiguration
{
    public class DespesaConfiguration : BaseConfiguration<Despesa>, IEntityTypeConfiguration<Despesa>
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
                .HasForeignKey(d => d.UsuarioId);

            builder
                .HasMany(d => d.Parcelas)
                .WithOne(p => p.Despesa)
                .HasForeignKey(p => p.DespesaId);

            builder
                .Property(p => p.EhAtivo)
                .IsRequired();

            builder
               .Property(p => p.EhRecorrente)
               .IsRequired();
        }
    }
}
