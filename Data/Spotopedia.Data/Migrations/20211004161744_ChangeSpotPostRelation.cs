using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spotopedia.Data.Migrations
{
    public partial class ChangeSpotPostRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpotPosts");

            migrationBuilder.AddColumn<int>(
                name: "SpotId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SpotId",
                table: "Posts",
                column: "SpotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Spots_SpotId",
                table: "Posts",
                column: "SpotId",
                principalTable: "Spots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Spots_SpotId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_SpotId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "SpotId",
                table: "Posts");

            migrationBuilder.CreateTable(
                name: "SpotPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    SpotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpotPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpotPosts_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpotPosts_Spots_SpotId",
                        column: x => x.SpotId,
                        principalTable: "Spots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpotPosts_IsDeleted",
                table: "SpotPosts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SpotPosts_PostId",
                table: "SpotPosts",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_SpotPosts_SpotId",
                table: "SpotPosts",
                column: "SpotId");
        }
    }
}
