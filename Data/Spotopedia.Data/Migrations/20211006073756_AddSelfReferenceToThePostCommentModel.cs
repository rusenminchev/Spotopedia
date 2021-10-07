using Microsoft.EntityFrameworkCore.Migrations;

namespace Spotopedia.Data.Migrations
{
    public partial class AddSelfReferenceToThePostCommentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "PostComments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_ParentId",
                table: "PostComments",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_PostComments_ParentId",
                table: "PostComments",
                column: "ParentId",
                principalTable: "PostComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_PostComments_ParentId",
                table: "PostComments");

            migrationBuilder.DropIndex(
                name: "IX_PostComments_ParentId",
                table: "PostComments");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "PostComments");
        }
    }
}
