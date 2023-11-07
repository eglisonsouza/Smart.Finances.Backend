using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Finances.DataAccess.Core.Entity;

namespace Smart.Finances.DataAccess.Infra.Persistence.Configurations.EntitiesConfiguration
{
    public class CategoriaConfiguration : BaseConfiguration<Categoria>, IEntityTypeConfiguration<Categoria>
    {
        public new void Configure(EntityTypeBuilder<Categoria> builder)
        {
            base.Configure(builder);

            builder
                .Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(p => p.EhAtivo).IsRequired();
        }
    }
}
