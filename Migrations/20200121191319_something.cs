using Microsoft.EntityFrameworkCore.Migrations;

namespace Pixgram_V1.Migrations
{
    public partial class something : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileCategory",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Images");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Images",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Images_CategoryId",
                table: "Images",
                column: "CategoryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Categories_CategoryId",
                table: "Images",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Categories_CategoryId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_CategoryId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "FileCategory",
                table: "Images",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Images",
                nullable: true);
        }
    }
}
