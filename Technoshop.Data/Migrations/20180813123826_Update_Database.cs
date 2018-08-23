using Microsoft.EntityFrameworkCore.Migrations;

namespace Technoshop.Data.Migrations
{
    public partial class Update_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BackCamera",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Battery",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Display",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrontCamera",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OS",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherPorts",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ports",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "USB",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackCamera",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Battery",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Display",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FrontCamera",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OS",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OtherPorts",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Ports",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "USB",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Products");
        }
    }
}
