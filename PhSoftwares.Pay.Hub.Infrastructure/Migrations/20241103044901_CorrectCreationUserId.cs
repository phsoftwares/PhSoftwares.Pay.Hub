using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhSoftwares.Pay.Hub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrectCreationUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationUsername",
                table: "Recipients",
                newName: "CreationUserId");

            migrationBuilder.RenameColumn(
                name: "CreationUsername",
                table: "Payments",
                newName: "CreationUserId");

            migrationBuilder.RenameColumn(
                name: "CreationUsername",
                table: "Payers",
                newName: "CreationUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationUserId",
                table: "Recipients",
                newName: "CreationUsername");

            migrationBuilder.RenameColumn(
                name: "CreationUserId",
                table: "Payments",
                newName: "CreationUsername");

            migrationBuilder.RenameColumn(
                name: "CreationUserId",
                table: "Payers",
                newName: "CreationUsername");
        }
    }
}
