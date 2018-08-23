using Microsoft.EntityFrameworkCore.Migrations;

namespace Technoshop.Data.Migrations
{
    public partial class UpdateProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RAMType",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StorageType",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Storage",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "RAM",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Storage",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RAM",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RAMType",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StorageType",
                table: "Products",
                nullable: true);
        }
    }
}
