using Microsoft.EntityFrameworkCore.Migrations;

namespace Tecoora.DataContext.Migrations
{
    public partial class addlawyerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LawyerId",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LawyerId",
                table: "Reviews");
        }
    }
}
