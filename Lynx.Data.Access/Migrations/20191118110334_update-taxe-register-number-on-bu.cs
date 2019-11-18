using Microsoft.EntityFrameworkCore.Migrations;

namespace Lynx.Data.Access.Migrations
{
    public partial class updatetaxeregisternumberonbu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaxeId",
                table: "BusinessUnit");

            migrationBuilder.AddColumn<string>(
                name: "TaxeResisterNumber",
                table: "BusinessUnit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaxeResisterNumber",
                table: "BusinessUnit");

            migrationBuilder.AddColumn<string>(
                name: "TaxeId",
                table: "BusinessUnit",
                type: "text",
                nullable: true);
        }
    }
}
