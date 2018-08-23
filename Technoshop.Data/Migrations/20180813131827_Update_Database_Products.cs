using Microsoft.EntityFrameworkCore.Migrations;

namespace Technoshop.Data.Migrations
{
    public partial class Update_Database_Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OtherPorts",
                table: "Products");

            migrationBuilder.AddColumn<bool>(
                name: "HDMI",
                table: "Products",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HDMI",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "OtherPorts",
                table: "Products",
                nullable: true);
        }
    }
}
