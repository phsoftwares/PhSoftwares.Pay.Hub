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
    internal class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder) 
        { 
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.FullName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.EmailAddress).HasMaxLength(200).IsRequired();
            builder.Property(x => x.DocumentNumber).HasMaxLength(20).IsRequired();
            builder.Property(x => x.CreatedDateTime).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.UpdatedDateTime).HasColumnType("datetime");
        }

    }
}
