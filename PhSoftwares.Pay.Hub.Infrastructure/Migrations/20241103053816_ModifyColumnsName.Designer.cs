﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhSoftwares.Pay.Hub.Infrastructure.Context;

#nullable disable

namespace PhSoftwares.Pay.Hub.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241103053816_ModifyColumnsName")]
    partial class ModifyColumnsName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("PhSoftwares.Pay.Hub.Core.Entities.FinancialInstitution", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FinancialInstitutions");
                });

            modelBuilder.Entity("PhSoftwares.Pay.Hub.Core.Entities.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<Guid>("CreationUserId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("DiscountValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("FinancialInstitutionId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("GrossValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IncreaseValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NetValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("PayerId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PaymentTypeId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PayeeId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FinancialInstitutionId");

                    b.HasIndex("PaymentTypeId");

                    b.HasIndex("PayeeId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("PhSoftwares.Pay.Hub.Core.Entities.PaymentType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("PhSoftwares.Pay.Hub.Core.Entities.Person.Payer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressCity")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressCountry")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressNeighborhood")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressState")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressStreet")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<Guid>("CreationUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Payers");
                });

            modelBuilder.Entity("PhSoftwares.Pay.Hub.Core.Entities.Person.Payee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressCity")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressCountry")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressNeighborhood")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressState")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressStreet")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("BankAccount")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BankAgency")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<Guid>("CreationUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Payees");
                });

            modelBuilder.Entity("PhSoftwares.Pay.Hub.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PhSoftwares.Pay.Hub.Core.Entities.Payment", b =>
                {
                    b.HasOne("PhSoftwares.Pay.Hub.Core.Entities.FinancialInstitution", "FinancialInstitution")
                        .WithMany("Payments")
                        .HasForeignKey("FinancialInstitutionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PhSoftwares.Pay.Hub.Core.Entities.PaymentType", "PaymentType")
                        .WithMany("Payments")
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PhSoftwares.Pay.Hub.Core.Entities.Person.Payer", "Payer")
                        .WithMany("Payments")
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PhSoftwares.Pay.Hub.Core.Entities.Person.Payee", "Payee")
                        .WithMany("Payments")
                        .HasForeignKey("PayeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FinancialInstitution");

                    b.Navigation("Payer");

                    b.Navigation("PaymentType");

                    b.Navigation("Payee");
                });

            modelBuilder.Entity("PhSoftwares.Pay.Hub.Core.Entities.FinancialInstitution", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("PhSoftwares.Pay.Hub.Core.Entities.PaymentType", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("PhSoftwares.Pay.Hub.Core.Entities.Person.Payer", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("PhSoftwares.Pay.Hub.Core.Entities.Person.Payee", b =>
                {
                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
