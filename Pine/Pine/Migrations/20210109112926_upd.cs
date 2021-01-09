using Microsoft.EntityFrameworkCore.Migrations;

namespace Pine.Migrations
{
    public partial class upd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostId",
                table: "posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PostId",
                table: "posts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
