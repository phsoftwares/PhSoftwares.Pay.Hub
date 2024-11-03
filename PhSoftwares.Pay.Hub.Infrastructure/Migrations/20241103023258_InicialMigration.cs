using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhSoftwares.Pay.Hub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InicialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinancialInstitutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccountNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Document = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialInstitutions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    DocumentNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreationUsername = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AddressStreet = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    AddressNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    AddressNeighborhood = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    AddressCity = table.Column<string>(type: "TEXT", nullable: false),
                    AddressCountry = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    AddressState = table.Column<string>(type: "TEXT", maxLength: 2, nullable: false),
                    ZipCode = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    BankAgency = table.Column<string>(type: "TEXT", nullable: false),
                    BankAccount = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    DocumentNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreationUsername = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AddressStreet = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    AddressNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    AddressNeighborhood = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    AddressCity = table.Column<string>(type: "TEXT", nullable: false),
                    AddressCountry = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    AddressState = table.Column<string>(type: "TEXT", maxLength: 2, nullable: false),
                    ZipCode = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NetValue = table.Column<decimal>(type: "TEXT", nullable: false),
                    GrossValue = table.Column<decimal>(type: "TEXT", nullable: false),
                    DiscountValue = table.Column<decimal>(type: "TEXT", nullable: false),
                    IncreaseValue = table.Column<decimal>(type: "TEXT", nullable: false),
                    PaymentTypeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FinancialInstitutionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PayerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RecipientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreationUsername = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_FinancialInstitutions_FinancialInstitutionId",
                        column: x => x.FinancialInstitutionId,
                        principalTable: "FinancialInstitutions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payments_Payers_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "Payers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payments_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payments_Recipients_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Recipients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_FinancialInstitutionId",
                table: "Payments",
                column: "FinancialInstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentTypeId",
                table: "Payments",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_RecipientId",
                table: "Payments",
                column: "RecipientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "FinancialInstitutions");

            migrationBuilder.DropTable(
                name: "Payers");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "Recipients");
        }
    }
}
