using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pine.Migrations
{
    public partial class chat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Chatid",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "chats",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chats", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Chatid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.id);
                    table.ForeignKey(
                        name: "FK_messages_chats_Chatid",
                        column: x => x.Chatid,
                        principalTable: "chats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Chatid",
                table: "AspNetUsers",
                column: "Chatid");

            migrationBuilder.CreateIndex(
                name: "IX_messages_Chatid",
                table: "messages",
                column: "Chatid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_chats_Chatid",
                table: "AspNetUsers",
                column: "Chatid",
                principalTable: "chats",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_chats_Chatid",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "chats");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Chatid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Chatid",
                table: "AspNetUsers");
        }
    }
}
