using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Lynx.Data.Access.Migrations
{
    public partial class updatetablenames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessUnit_Client_ClientId",
                table: "BusinessUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessUnit_Users_ManagerId",
                table: "BusinessUnit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessUnit",
                table: "BusinessUnit");

            migrationBuilder.RenameTable(
                name: "BusinessUnit",
                newName: "BusinessUnits");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessUnit_ManagerId",
                table: "BusinessUnits",
                newName: "IX_BusinessUnits_ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessUnit_ClientId",
                table: "BusinessUnits",
                newName: "IX_BusinessUnits_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessUnits",
                table: "BusinessUnits",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserBusinessUnits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(nullable: false),
                    BusinessUnitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBusinessUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBusinessUnits_BusinessUnits_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBusinessUnits_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBusinessUnits_BusinessUnitId",
                table: "UserBusinessUnits",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBusinessUnits_UserId",
                table: "UserBusinessUnits",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessUnits_Client_ClientId",
                table: "BusinessUnits",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessUnits_Users_ManagerId",
                table: "BusinessUnits",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessUnits_Client_ClientId",
                table: "BusinessUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessUnits_Users_ManagerId",
                table: "BusinessUnits");

            migrationBuilder.DropTable(
                name: "UserBusinessUnits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessUnits",
                table: "BusinessUnits");

            migrationBuilder.RenameTable(
                name: "BusinessUnits",
                newName: "BusinessUnit");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessUnits_ManagerId",
                table: "BusinessUnit",
                newName: "IX_BusinessUnit_ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessUnits_ClientId",
                table: "BusinessUnit",
                newName: "IX_BusinessUnit_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessUnit",
                table: "BusinessUnit",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessUnit_Client_ClientId",
                table: "BusinessUnit",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessUnit_Users_ManagerId",
                table: "BusinessUnit",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
