using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spotopedia.Data.Migrations
{
    public partial class SpotModelsChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpotCommentVotes");

            migrationBuilder.DropTable(
                name: "SpotComments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpotComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SpotId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpotId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpotComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpotComments_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpotComments_Spots_SpotId1",
                        column: x => x.SpotId1,
                        principalTable: "Spots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpotCommentVotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SpotCommentId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpotCommentVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpotCommentVotes_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpotCommentVotes_SpotComments_SpotCommentId",
                        column: x => x.SpotCommentId,
                        principalTable: "SpotComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpotComments_AddedByUserId",
                table: "SpotComments",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SpotComments_IsDeleted",
                table: "SpotComments",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SpotComments_SpotId1",
                table: "SpotComments",
                column: "SpotId1");

            migrationBuilder.CreateIndex(
                name: "IX_SpotCommentVotes_AddedByUserId",
                table: "SpotCommentVotes",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SpotCommentVotes_IsDeleted",
                table: "SpotCommentVotes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SpotCommentVotes_SpotCommentId",
                table: "SpotCommentVotes",
                column: "SpotCommentId");
        }
    }
}
