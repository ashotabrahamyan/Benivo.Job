using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class RenameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Categories_CategorieId",
                table: "Job");

            migrationBuilder.RenameColumn(
                name: "CategorieId",
                table: "Job",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Job_CategorieId",
                table: "Job",
                newName: "IX_Job_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Categories_CategoryId",
                table: "Job",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Categories_CategoryId",
                table: "Job");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Job",
                newName: "CategorieId");

            migrationBuilder.RenameIndex(
                name: "IX_Job_CategoryId",
                table: "Job",
                newName: "IX_Job_CategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Categories_CategorieId",
                table: "Job",
                column: "CategorieId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
