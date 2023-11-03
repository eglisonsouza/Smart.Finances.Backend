using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Finances.DataAccess.Core.Entity;

namespace Smart.Finances.DataAccess.Infra.Persistence.Configurations.EntitiesConfiguration
{
    public class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            builder
                .Property(p => p.CriadoEm)
                .IsRequired();
            builder
                .Property(p => p.AtualizadoEm);
        }
    }
}
