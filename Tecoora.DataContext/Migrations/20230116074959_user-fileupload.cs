using Microsoft.EntityFrameworkCore.Migrations;

namespace Tecoora.DataContext.Migrations
{
    public partial class userfileupload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LawyerRequestedFiles_FileType_FileTypeId",
                table: "LawyerRequestedFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFileDetails_FileType_FileTypeId",
                table: "UserFileDetails");

            migrationBuilder.DropTable(
                name: "FileType");

            migrationBuilder.DropIndex(
                name: "IX_UserFileDetails_FileTypeId",
                table: "UserFileDetails");

            migrationBuilder.DropIndex(
                name: "IX_LawyerRequestedFiles_FileTypeId",
                table: "LawyerRequestedFiles");

            migrationBuilder.DropColumn(
                name: "FileTypeId",
                table: "LawyerRequestedFiles");

            migrationBuilder.AddColumn<int>(
                name: "FileType",
                table: "LawyerRequestedFiles",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileType",
                table: "LawyerRequestedFiles");

            migrationBuilder.AddColumn<int>(
                name: "FileTypeId",
                table: "LawyerRequestedFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FileType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titile = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFileDetails_FileTypeId",
                table: "UserFileDetails",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LawyerRequestedFiles_FileTypeId",
                table: "LawyerRequestedFiles",
                column: "FileTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LawyerRequestedFiles_FileType_FileTypeId",
                table: "LawyerRequestedFiles",
                column: "FileTypeId",
                principalTable: "FileType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFileDetails_FileType_FileTypeId",
                table: "UserFileDetails",
                column: "FileTypeId",
                principalTable: "FileType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
