using Microsoft.EntityFrameworkCore.Migrations;

namespace Pine.Migrations
{
    public partial class sender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "senderName",
                table: "messages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "senderName",
                table: "messages");
        }
    }
}
