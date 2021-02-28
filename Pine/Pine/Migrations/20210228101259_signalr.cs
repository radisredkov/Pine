using Microsoft.EntityFrameworkCore.Migrations;

namespace Pine.Migrations
{
    public partial class signalr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_messages_chats_Chatid",
                table: "messages");

            migrationBuilder.RenameColumn(
                name: "Chatid",
                table: "messages",
                newName: "chatId");

            migrationBuilder.RenameIndex(
                name: "IX_messages_Chatid",
                table: "messages",
                newName: "IX_messages_chatId");

            migrationBuilder.AddForeignKey(
                name: "FK_messages_chats_chatId",
                table: "messages",
                column: "chatId",
                principalTable: "chats",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_messages_chats_chatId",
                table: "messages");

            migrationBuilder.RenameColumn(
                name: "chatId",
                table: "messages",
                newName: "Chatid");

            migrationBuilder.RenameIndex(
                name: "IX_messages_chatId",
                table: "messages",
                newName: "IX_messages_Chatid");

            migrationBuilder.AddForeignKey(
                name: "FK_messages_chats_Chatid",
                table: "messages",
                column: "Chatid",
                principalTable: "chats",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
