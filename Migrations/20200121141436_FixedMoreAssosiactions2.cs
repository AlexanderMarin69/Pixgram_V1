using Microsoft.EntityFrameworkCore.Migrations;

namespace Pixgram_V1.Migrations
{
    public partial class FixedMoreAssosiactions2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileCategory",
                table: "FileUploads");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "FileUploads");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileCategory",
                table: "FileUploads",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "FileUploads",
                nullable: true);
        }
    }
}
