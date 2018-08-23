using Microsoft.EntityFrameworkCore.Migrations;

namespace Technoshop.Data.Migrations
{
    public partial class Change_Products_Model_ModelName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Products",
                newName: "ModelName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModelName",
                table: "Products",
                newName: "Model");
        }
    }
}
