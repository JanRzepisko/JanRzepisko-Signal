using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Signal.App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class photoPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "_users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "_users",
                newName: "PhotoPath");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "_messages",
                newName: "Content");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "_users",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "PhotoPath",
                table: "_users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "_messages",
                newName: "Text");
        }
    }
}
