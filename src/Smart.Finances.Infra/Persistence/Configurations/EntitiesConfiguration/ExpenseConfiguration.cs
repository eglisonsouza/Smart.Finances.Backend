using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Finances.Core.Entity;

namespace Smart.Finances.Infra.Persistence.Configurations.EntitiesConfiguration
{
    public class ExpenseConfiguration : BaseConfiguration<Expense>, IEntityTypeConfiguration<Expense>
    {

        public new void Configure(EntityTypeBuilder<Expense> builder)
        {
            base.Configure(builder);

            builder
                 .Property(p => p.Description);
            builder
                .Property(p => p.Value)
                .IsRequired();

            builder
                .HasOne(d => d.Category);

            builder
                .Property(p => p.QuantityInstallment)
                .IsRequired();

            builder
                .HasOne(d => d.User)
                .WithMany(u => u.Expenses)
                .HasForeignKey(d => d.UserId);

            builder
                .HasMany(d => d.Installments)
                .WithOne(p => p.Expense)
                .HasForeignKey(p => p.ExpenseId);

            builder
                .Property(p => p.IsActive)
                .IsRequired();

            builder
               .Property(p => p.IsMonthly)
               .IsRequired();
        }
    }
}
