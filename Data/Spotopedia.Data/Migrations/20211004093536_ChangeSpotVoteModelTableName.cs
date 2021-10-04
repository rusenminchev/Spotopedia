using Microsoft.EntityFrameworkCore.Migrations;

namespace Spotopedia.Data.Migrations
{
    public partial class ChangeSpotVoteModelTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpotsVotes_AspNetUsers_AddedByUserId",
                table: "SpotsVotes");

            migrationBuilder.DropForeignKey(
                name: "FK_SpotsVotes_Spots_SpotId",
                table: "SpotsVotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpotsVotes",
                table: "SpotsVotes");

            migrationBuilder.RenameTable(
                name: "SpotsVotes",
                newName: "SpotVotes");

            migrationBuilder.RenameIndex(
                name: "IX_SpotsVotes_SpotId",
                table: "SpotVotes",
                newName: "IX_SpotVotes_SpotId");

            migrationBuilder.RenameIndex(
                name: "IX_SpotsVotes_AddedByUserId",
                table: "SpotVotes",
                newName: "IX_SpotVotes_AddedByUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpotVotes",
                table: "SpotVotes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpotVotes_AspNetUsers_AddedByUserId",
                table: "SpotVotes",
                column: "AddedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpotVotes_Spots_SpotId",
                table: "SpotVotes",
                column: "SpotId",
                principalTable: "Spots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpotVotes_AspNetUsers_AddedByUserId",
                table: "SpotVotes");

            migrationBuilder.DropForeignKey(
                name: "FK_SpotVotes_Spots_SpotId",
                table: "SpotVotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpotVotes",
                table: "SpotVotes");

            migrationBuilder.RenameTable(
                name: "SpotVotes",
                newName: "SpotsVotes");

            migrationBuilder.RenameIndex(
                name: "IX_SpotVotes_SpotId",
                table: "SpotsVotes",
                newName: "IX_SpotsVotes_SpotId");

            migrationBuilder.RenameIndex(
                name: "IX_SpotVotes_AddedByUserId",
                table: "SpotsVotes",
                newName: "IX_SpotsVotes_AddedByUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpotsVotes",
                table: "SpotsVotes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpotsVotes_AspNetUsers_AddedByUserId",
                table: "SpotsVotes",
                column: "AddedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpotsVotes_Spots_SpotId",
                table: "SpotsVotes",
                column: "SpotId",
                principalTable: "Spots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
