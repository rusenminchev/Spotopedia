using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spotopedia.Data.Migrations
{
    public partial class CreateChallengeImageModelAndAddItToChallenge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChallengeImages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChallengeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallengeImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChallengeImages_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChallengeImages_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeImages_AddedByUserId",
                table: "ChallengeImages",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeImages_ChallengeId",
                table: "ChallengeImages",
                column: "ChallengeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeImages_IsDeleted",
                table: "ChallengeImages",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChallengeImages");
        }
    }
}
