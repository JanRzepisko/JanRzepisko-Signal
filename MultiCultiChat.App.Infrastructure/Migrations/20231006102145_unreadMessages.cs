using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Signal.App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class unreadMessages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SentDate",
                table: "_messages",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "UnreadMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MessageId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnreadMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnreadMessage__messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "_messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnreadMessage__users_UserId",
                        column: x => x.UserId,
                        principalTable: "_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UnreadMessage_MessageId",
                table: "UnreadMessage",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_UnreadMessage_UserId",
                table: "UnreadMessage",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnreadMessage");

            migrationBuilder.DropColumn(
                name: "SentDate",
                table: "_messages");
        }
    }
}
