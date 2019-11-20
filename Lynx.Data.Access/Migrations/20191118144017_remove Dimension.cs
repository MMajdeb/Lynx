using Microsoft.EntityFrameworkCore.Migrations;

namespace Lynx.Data.Access.Migrations
{
    public partial class removeDimension : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Length",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Discounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Length",
                table: "Discounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Discounts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "Discounts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Discounts");
        }
    }
}
