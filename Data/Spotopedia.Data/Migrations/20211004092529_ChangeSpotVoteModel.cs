using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spotopedia.Data.Migrations
{
    public partial class ChangeSpotVoteModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SpotsVotes_IsDeleted",
                table: "SpotsVotes");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "SpotsVotes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SpotsVotes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "SpotsVotes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SpotsVotes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_SpotsVotes_IsDeleted",
                table: "SpotsVotes",
                column: "IsDeleted");
        }
    }
}
