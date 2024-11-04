using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhSoftwares.Pay.Hub.Core.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Infrastructure.EntitiesConfiguration
{
    internal class PayeesConfiguration : IEntityTypeConfiguration<Payee>
    {
        public void Configure(EntityTypeBuilder<Payee> builder) 
        { 
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.FullName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.EmailAddress).HasMaxLength(200).IsRequired();
            builder.Property(x => x.DocumentNumber).HasMaxLength(20).IsRequired();
            builder.Property(x => x.CreatedDateTime).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.UpdatedDateTime).HasColumnType("datetime");
            builder.Property(x => x.AddressStreet).HasMaxLength(100).IsRequired();
            builder.Property(x => x.AddressNumber).HasMaxLength(20).IsRequired();
            builder.Property(x => x.AddressNeighborhood).HasMaxLength(100).IsRequired();
            builder.Property(x => x.AddressCountry).HasMaxLength(100).IsRequired();
            builder.Property(x => x.AddressState).HasMaxLength(2).IsRequired();
            builder.Property(x => x.ZipCode).HasMaxLength(20).IsRequired();
        }

    }
}
