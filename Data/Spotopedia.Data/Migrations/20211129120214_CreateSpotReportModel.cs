namespace Spotopedia.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class CreateSpotReportModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpotReports",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SpotReportType = table.Column<int>(type: "int", nullable: false),
                    ReportedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReportedUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReportedSpotId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpotReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpotReports_AspNetUsers_ReportedByUserId",
                        column: x => x.ReportedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpotReports_AspNetUsers_ReportedUserId",
                        column: x => x.ReportedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpotReports_Spots_ReportedSpotId",
                        column: x => x.ReportedSpotId,
                        principalTable: "Spots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpotReports_IsDeleted",
                table: "SpotReports",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SpotReports_ReportedByUserId",
                table: "SpotReports",
                column: "ReportedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SpotReports_ReportedSpotId",
                table: "SpotReports",
                column: "ReportedSpotId");

            migrationBuilder.CreateIndex(
                name: "IX_SpotReports_ReportedUserId",
                table: "SpotReports",
                column: "ReportedUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpotReports");
        }
    }
}
