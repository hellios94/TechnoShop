using Microsoft.EntityFrameworkCore.Migrations;

namespace Technoshop.Data.Migrations
{
    public partial class Remove_Brands_Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }
    }
}
