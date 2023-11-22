using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Finances.Core.Entity;

namespace Smart.Finances.Infra.Persistence.Configurations.EntitiesConfiguration
{
    public class UserConfiguration : BaseConfiguration<User>, IEntityTypeConfiguration<User>
    {
        public new void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(p => p.Password)
                .IsRequired();
            builder
                .Property(p => p.Email)
                .IsRequired();

            builder
                .HasMany(u => u.Expenses)
                .WithOne(d => d.User)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
