using Microsoft.EntityFrameworkCore.Migrations;

namespace Spotopedia.Data.Migrations
{
    public partial class AddChallengeIdCollumnToPostModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChallengeId",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ChallengeId",
                table: "Posts",
                column: "ChallengeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Challenges_ChallengeId",
                table: "Posts",
                column: "ChallengeId",
                principalTable: "Challenges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Challenges_ChallengeId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ChallengeId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ChallengeId",
                table: "Posts");
        }
    }
}
