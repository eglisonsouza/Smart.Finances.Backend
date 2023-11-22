using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Finances.Core.Entity;

namespace Smart.Finances.Infra.Persistence.Configurations.EntitiesConfiguration
{
    public class CategoryConfiguration : BaseConfiguration<Category>, IEntityTypeConfiguration<Category>
    {
        public new void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder
                .Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(p => p.IsActive).IsRequired();
        }
    }
}
