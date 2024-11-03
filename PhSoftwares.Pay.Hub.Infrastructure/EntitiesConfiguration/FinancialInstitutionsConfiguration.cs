using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhSoftwares.Pay.Hub.Core.Entities;

namespace PhSoftwares.Pay.Hub.Infrastructure.EntitiesConfiguration
{
    internal class FinancialInstitutionsConfiguration : IEntityTypeConfiguration<FinancialInstitution>
    {
        public void Configure(EntityTypeBuilder<FinancialInstitution> builder) 
        { 
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.AccountNumber).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Document).HasMaxLength(20).IsRequired();
        }

    }
}
