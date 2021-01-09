using Microsoft.EntityFrameworkCore.Migrations;

namespace Pine.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_communities_communityId",
                table: "posts");

            migrationBuilder.RenameColumn(
                name: "communityId",
                table: "posts",
                newName: "Communityid");

            migrationBuilder.RenameIndex(
                name: "IX_posts_communityId",
                table: "posts",
                newName: "IX_posts_Communityid");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_communities_Communityid",
                table: "posts",
                column: "Communityid",
                principalTable: "communities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_communities_Communityid",
                table: "posts");

            migrationBuilder.RenameColumn(
                name: "Communityid",
                table: "posts",
                newName: "communityId");

            migrationBuilder.RenameIndex(
                name: "IX_posts_Communityid",
                table: "posts",
                newName: "IX_posts_communityId");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_communities_communityId",
                table: "posts",
                column: "communityId",
                principalTable: "communities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
