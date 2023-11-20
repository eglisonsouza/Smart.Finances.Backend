using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Finances.Core.Entity;

namespace Smart.Finances.Infra.Persistence.Configurations.EntitiesConfiguration
{
    public class ParcelasConfiguration : BaseConfiguration<Parcelas>, IEntityTypeConfiguration<Parcelas>
    {
        public new void Configure(EntityTypeBuilder<Parcelas> builder)
        {
            base.Configure(builder);

            builder
                .Property(p => p.Vencimento)
                .IsRequired();
            builder
                .Property(p => p.Numero)
                .IsRequired();
            builder
                .Property(p => p.Descricao)
                .HasMaxLength(50);
            builder
                .Property(p => p.ValorParcela)
                .IsRequired();
            builder
                .Property(p => p.PagamentoEm);

        }
    }
}
