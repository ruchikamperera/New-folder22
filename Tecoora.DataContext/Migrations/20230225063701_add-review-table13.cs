using Microsoft.EntityFrameworkCore.Migrations;

namespace Tecoora.DataContext.Migrations
{
    public partial class addreviewtable13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OTP",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OTP",
                table: "Users");
        }
    }
}
