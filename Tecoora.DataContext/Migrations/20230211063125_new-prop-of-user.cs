using Microsoft.EntityFrameworkCore.Migrations;

namespace Tecoora.DataContext.Migrations
{
    public partial class newpropofuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileImageUrl",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceDescription",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImageUrl",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ServiceDescription",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Users");
        }
    }
}
