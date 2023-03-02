using Microsoft.EntityFrameworkCore.Migrations;

namespace Tecoora.DataContext.Migrations
{
    public partial class fileupload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileTypeId",
                table: "UserFileDetails");

            migrationBuilder.AddColumn<int>(
                name: "FileType",
                table: "UserFileDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileType",
                table: "UserFileDetails");

            migrationBuilder.AddColumn<int>(
                name: "FileTypeId",
                table: "UserFileDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
