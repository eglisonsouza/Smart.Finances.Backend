using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;
using Smart.Finances.DataAccess.Core.Entity;

namespace Smart.Finances.DataAccess.Infra.Persistence.Configurations.EntitiesConfiguration
{
    public class DespesaRecorrenteConfiguration : IEntityTypeConfiguration<DespesaRecorrente>
    {
        public void Configure(EntityTypeBuilder<DespesaRecorrente> builder)
        {
            builder
                .Property(p => p.EhAtivo)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasOne(d => d.Usuario)
                .WithMany(u => u.DespesasRecorrente)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
