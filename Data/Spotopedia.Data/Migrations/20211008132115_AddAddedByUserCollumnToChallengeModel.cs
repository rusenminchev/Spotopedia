using Microsoft.EntityFrameworkCore.Migrations;

namespace Spotopedia.Data.Migrations
{
    public partial class AddAddedByUserCollumnToChallengeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddedByUserId",
                table: "Challenges",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_AddedByUserId",
                table: "Challenges",
                column: "AddedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Challenges_AspNetUsers_AddedByUserId",
                table: "Challenges",
                column: "AddedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Challenges_AspNetUsers_AddedByUserId",
                table: "Challenges");

            migrationBuilder.DropIndex(
                name: "IX_Challenges_AddedByUserId",
                table: "Challenges");

            migrationBuilder.DropColumn(
                name: "AddedByUserId",
                table: "Challenges");
        }
    }
}
