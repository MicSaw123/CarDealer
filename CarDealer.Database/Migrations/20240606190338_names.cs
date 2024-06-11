using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealer.Database.Migrations
{
    /// <inheritdoc />
    public partial class names : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Transmissions",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DrivetrainName",
                table: "Drivetrains",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ColorName",
                table: "CarColors",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Transmissions",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Drivetrains",
                newName: "DrivetrainName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CarColors",
                newName: "ColorName");
        }
    }
}
