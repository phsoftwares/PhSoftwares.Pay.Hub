using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhSoftwares.Pay.Hub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyColumnsName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateDateTime",
                table: "Users",
                newName: "UpdatedDateTime");

            migrationBuilder.RenameColumn(
                name: "UpdateDateTime",
                table: "Payees",
                newName: "UpdatedDateTime");

            migrationBuilder.RenameColumn(
                name: "UpdateDateTime",
                table: "Payments",
                newName: "UpdatedDateTime");

            migrationBuilder.RenameColumn(
                name: "UpdateDateTime",
                table: "Payers",
                newName: "UpdatedDateTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "PaymentTypes",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "FinancialInstitutions",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "PaymentTypes");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "FinancialInstitutions");

            migrationBuilder.RenameColumn(
                name: "UpdatedDateTime",
                table: "Users",
                newName: "UpdateDateTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedDateTime",
                table: "Payees",
                newName: "UpdateDateTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedDateTime",
                table: "Payments",
                newName: "UpdateDateTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedDateTime",
                table: "Payers",
                newName: "UpdateDateTime");
        }
    }
}
