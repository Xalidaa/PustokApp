using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCPustokApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Features",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Features_CategoryId",
                table: "Features",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Categories_CategoryId",
                table: "Features",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Categories_CategoryId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_CategoryId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Features");
        }
    }
}
