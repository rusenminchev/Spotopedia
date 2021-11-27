using Microsoft.EntityFrameworkCore.Migrations;

namespace Spotopedia.Data.Migrations
{
    public partial class AddReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Report_AspNetUsers_ReportedByUserId",
                table: "Report");

            migrationBuilder.DropForeignKey(
                name: "FK_Report_AspNetUsers_ReportedUserId",
                table: "Report");

            migrationBuilder.DropForeignKey(
                name: "FK_Report_Posts_ReportedPostId",
                table: "Report");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Report",
                table: "Report");

            migrationBuilder.RenameTable(
                name: "Report",
                newName: "Reports");

            migrationBuilder.RenameIndex(
                name: "IX_Report_ReportedUserId",
                table: "Reports",
                newName: "IX_Reports_ReportedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Report_ReportedPostId",
                table: "Reports",
                newName: "IX_Reports_ReportedPostId");

            migrationBuilder.RenameIndex(
                name: "IX_Report_ReportedByUserId",
                table: "Reports",
                newName: "IX_Reports_ReportedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Report_IsDeleted",
                table: "Reports",
                newName: "IX_Reports_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reports",
                table: "Reports",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_AspNetUsers_ReportedByUserId",
                table: "Reports",
                column: "ReportedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_AspNetUsers_ReportedUserId",
                table: "Reports",
                column: "ReportedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Posts_ReportedPostId",
                table: "Reports",
                column: "ReportedPostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AspNetUsers_ReportedByUserId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AspNetUsers_ReportedUserId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Posts_ReportedPostId",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reports",
                table: "Reports");

            migrationBuilder.RenameTable(
                name: "Reports",
                newName: "Report");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_ReportedUserId",
                table: "Report",
                newName: "IX_Report_ReportedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_ReportedPostId",
                table: "Report",
                newName: "IX_Report_ReportedPostId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_ReportedByUserId",
                table: "Report",
                newName: "IX_Report_ReportedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_IsDeleted",
                table: "Report",
                newName: "IX_Report_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Report",
                table: "Report",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Report_AspNetUsers_ReportedByUserId",
                table: "Report",
                column: "ReportedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Report_AspNetUsers_ReportedUserId",
                table: "Report",
                column: "ReportedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Report_Posts_ReportedPostId",
                table: "Report",
                column: "ReportedPostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
