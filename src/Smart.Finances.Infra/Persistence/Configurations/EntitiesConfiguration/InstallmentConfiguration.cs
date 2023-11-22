using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Finances.Core.Entity;

namespace Smart.Finances.Infra.Persistence.Configurations.EntitiesConfiguration
{
    public class InstallmentConfiguration : BaseConfiguration<Installment>, IEntityTypeConfiguration<Installment>
    {
        public new void Configure(EntityTypeBuilder<Installment> builder)
        {
            base.Configure(builder);

            builder
                .Property(p => p.DueDate)
                .IsRequired();
            builder
                .Property(p => p.Number)
                .IsRequired();
            builder
                .Property(p => p.Description)
                .HasMaxLength(50);
            builder
                .Property(p => p.Value)
                .IsRequired();
            builder
                .Property(p => p.PaymentIn);

        }
    }
}
