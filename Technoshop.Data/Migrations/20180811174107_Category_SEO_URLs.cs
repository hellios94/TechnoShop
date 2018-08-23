using Microsoft.EntityFrameworkCore.Migrations;

namespace Technoshop.Data.Migrations
{
    public partial class Category_SEO_URLs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Brands",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Brands");
        }
    }
}
