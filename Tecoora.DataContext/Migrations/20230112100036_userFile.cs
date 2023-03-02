using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tecoora.DataContext.Migrations
{
    public partial class userFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titile = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LawyerRequestedFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    LawyerId = table.Column<int>(nullable: false),
                    FileTypeId = table.Column<int>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LawyerRequestedFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LawyerRequestedFiles_FileType_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFileDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    LawyerId = table.Column<int>(nullable: false),
                    FileTypeId = table.Column<int>(nullable: false),
                    FileUrl = table.Column<string>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFileDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFileDetails_FileType_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LawyerRequestedFiles_FileTypeId",
                table: "LawyerRequestedFiles",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFileDetails_FileTypeId",
                table: "UserFileDetails",
                column: "FileTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LawyerRequestedFiles");

            migrationBuilder.DropTable(
                name: "UserFileDetails");

            migrationBuilder.DropTable(
                name: "FileType");
        }
    }
}
