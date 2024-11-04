using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhSoftwares.Pay.Hub.Core.Entities;
using PhSoftwares.Pay.Hub.Core.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Infrastructure.EntitiesConfiguration
{
    internal class PaymentsConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder) 
        { 
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.NetValue).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.GrossValue).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.DiscountValue).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.CreatedDateTime).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.IncreaseValue).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.PayeeId).IsRequired();
            builder.Property(x => x.PayerId).IsRequired();
            builder.Property(x => x.FinancialInstitutionId).IsRequired();
            builder.Property(x => x.PaymentTypeId).IsRequired();

            builder.HasOne(x => x.Payer).WithMany(x => x.Payments)
                .HasForeignKey(x => x.PaymentTypeId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Payee).WithMany(x => x.Payments)
                .HasForeignKey(x => x.PayeeId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.FinancialInstitution).WithMany(x => x.Payments)
                .HasForeignKey(x => x.FinancialInstitutionId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.PaymentType).WithMany(x => x.Payments)
                .HasForeignKey(x => x.PaymentTypeId).OnDelete(DeleteBehavior.NoAction);
        }

    }
}
