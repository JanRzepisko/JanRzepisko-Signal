using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Signal.App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class configs2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatUser_Chat_ChatId",
                table: "ChatUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatUser__users_UserId",
                table: "ChatUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Chat_ChatId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message__users_SenderId",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatUser",
                table: "ChatUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chat",
                table: "Chat");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "_messages");

            migrationBuilder.RenameTable(
                name: "ChatUser",
                newName: "_chatUsers");

            migrationBuilder.RenameTable(
                name: "Chat",
                newName: "_chats");

            migrationBuilder.RenameIndex(
                name: "IX_Message_SenderId",
                table: "_messages",
                newName: "IX__messages_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_ChatId",
                table: "_messages",
                newName: "IX__messages_ChatId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatUser_UserId",
                table: "_chatUsers",
                newName: "IX__chatUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatUser_ChatId",
                table: "_chatUsers",
                newName: "IX__chatUsers_ChatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK__messages",
                table: "_messages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__chatUsers",
                table: "_chatUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__chats",
                table: "_chats",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__chatUsers__chats_ChatId",
                table: "_chatUsers",
                column: "ChatId",
                principalTable: "_chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__chatUsers__users_UserId",
                table: "_chatUsers",
                column: "UserId",
                principalTable: "_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__messages__chats_ChatId",
                table: "_messages",
                column: "ChatId",
                principalTable: "_chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__messages__users_SenderId",
                table: "_messages",
                column: "SenderId",
                principalTable: "_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__chatUsers__chats_ChatId",
                table: "_chatUsers");

            migrationBuilder.DropForeignKey(
                name: "FK__chatUsers__users_UserId",
                table: "_chatUsers");

            migrationBuilder.DropForeignKey(
                name: "FK__messages__chats_ChatId",
                table: "_messages");

            migrationBuilder.DropForeignKey(
                name: "FK__messages__users_SenderId",
                table: "_messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK__messages",
                table: "_messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK__chatUsers",
                table: "_chatUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK__chats",
                table: "_chats");

            migrationBuilder.RenameTable(
                name: "_messages",
                newName: "Message");

            migrationBuilder.RenameTable(
                name: "_chatUsers",
                newName: "ChatUser");

            migrationBuilder.RenameTable(
                name: "_chats",
                newName: "Chat");

            migrationBuilder.RenameIndex(
                name: "IX__messages_SenderId",
                table: "Message",
                newName: "IX_Message_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX__messages_ChatId",
                table: "Message",
                newName: "IX_Message_ChatId");

            migrationBuilder.RenameIndex(
                name: "IX__chatUsers_UserId",
                table: "ChatUser",
                newName: "IX_ChatUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX__chatUsers_ChatId",
                table: "ChatUser",
                newName: "IX_ChatUser_ChatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatUser",
                table: "ChatUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chat",
                table: "Chat",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUser_Chat_ChatId",
                table: "ChatUser",
                column: "ChatId",
                principalTable: "Chat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUser__users_UserId",
                table: "ChatUser",
                column: "UserId",
                principalTable: "_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Chat_ChatId",
                table: "Message",
                column: "ChatId",
                principalTable: "Chat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message__users_SenderId",
                table: "Message",
                column: "SenderId",
                principalTable: "_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
