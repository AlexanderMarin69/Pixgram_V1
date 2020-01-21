using Microsoft.EntityFrameworkCore.Migrations;

namespace Pixgram_V1.Migrations
{
    public partial class FixedAssosiactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "FileUploadId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "AssociatedImageGuid",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Images",
                newName: "FileName");

            migrationBuilder.RenameColumn(
                name: "ImageGuid",
                table: "Images",
                newName: "FileCategory");

            migrationBuilder.AddColumn<string>(
                name: "FileCategory",
                table: "FileUploads",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "FileUploads",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileCategory",
                table: "FileUploads");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "FileUploads");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Images",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FileCategory",
                table: "Images",
                newName: "ImageGuid");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Images",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FileUploadId",
                table: "Images",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AssociatedImageGuid",
                table: "Categories",
                nullable: true);
        }
    }
}
