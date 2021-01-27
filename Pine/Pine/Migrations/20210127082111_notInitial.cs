using Microsoft.EntityFrameworkCore.Migrations;

namespace Pine.Migrations
{
    public partial class notInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "commentatorId",
                table: "comments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "commentatorId",
                table: "comments");
        }
    }
}
