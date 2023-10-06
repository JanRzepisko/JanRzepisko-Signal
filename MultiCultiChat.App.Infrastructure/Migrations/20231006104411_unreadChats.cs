using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Signal.App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class unreadChats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnreadMessage");

            migrationBuilder.CreateTable(
                name: "UnreadChat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ChatId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MessageId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnreadChat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnreadChat__chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "_chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnreadChat__messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "_messages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UnreadChat__users_UserId",
                        column: x => x.UserId,
                        principalTable: "_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UnreadChat_ChatId",
                table: "UnreadChat",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_UnreadChat_MessageId",
                table: "UnreadChat",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_UnreadChat_UserId",
                table: "UnreadChat",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnreadChat");

            migrationBuilder.CreateTable(
                name: "UnreadMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MessageId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
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
    }
}
