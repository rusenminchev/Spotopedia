using Microsoft.EntityFrameworkCore.Migrations;

namespace Spotopedia.Data.Migrations
{
    public partial class ChangeChallengeEntryImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChallengeEntrySpots_ChallengeEntries_ChallengeEntryId",
                table: "ChallengeEntrySpots");

            migrationBuilder.DropIndex(
                name: "IX_ChallengeEntrySpots_ChallengeEntryId",
                table: "ChallengeEntrySpots");

            migrationBuilder.DropIndex(
                name: "IX_ChallengeEntryImages_ChallengeEntryId",
                table: "ChallengeEntryImages");

            migrationBuilder.DropColumn(
                name: "ChallengeEntryId",
                table: "ChallengeEntrySpots");

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeEntryImages_ChallengeEntryId",
                table: "ChallengeEntryImages",
                column: "ChallengeEntryId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ChallengeEntryImages_ChallengeEntryId",
                table: "ChallengeEntryImages");

            migrationBuilder.AddColumn<int>(
                name: "ChallengeEntryId",
                table: "ChallengeEntrySpots",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeEntrySpots_ChallengeEntryId",
                table: "ChallengeEntrySpots",
                column: "ChallengeEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeEntryImages_ChallengeEntryId",
                table: "ChallengeEntryImages",
                column: "ChallengeEntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChallengeEntrySpots_ChallengeEntries_ChallengeEntryId",
                table: "ChallengeEntrySpots",
                column: "ChallengeEntryId",
                principalTable: "ChallengeEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
