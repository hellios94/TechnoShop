using Microsoft.EntityFrameworkCore.Migrations;

namespace Technoshop.Data.Migrations
{
    public partial class CategoryPicUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryPicUrl",
                table: "Categories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryPicUrl",
                table: "Categories");
        }
    }
}
