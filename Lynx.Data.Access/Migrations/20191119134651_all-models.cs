using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Lynx.Data.Access.Migrations
{
    public partial class allmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BankId",
                table: "Bills",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BusinessUnitId",
                table: "Bills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CashierId",
                table: "Bills",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BankName = table.Column<string>(nullable: true),
                    Iban = table.Column<string>(nullable: true),
                    Balance = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cashiers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Balance = table.Column<double>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    BusinessUnitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cashiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cashiers_BusinessUnits_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Reference = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    PartnerId = table.Column<int>(nullable: false),
                    BillId = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Rest = table.Column<double>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transferts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(nullable: false),
                    FromBankId = table.Column<int>(nullable: true),
                    ToBankId = table.Column<int>(nullable: true),
                    FromCashierId = table.Column<int>(nullable: true),
                    ToCashierId = table.Column<int>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    TransertDate = table.Column<DateTime>(nullable: false),
                    OperationDate = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transferts_Banks_FromBankId",
                        column: x => x.FromBankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transferts_Cashiers_FromCashierId",
                        column: x => x.FromCashierId,
                        principalTable: "Cashiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transferts_Banks_ToBankId",
                        column: x => x.ToBankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transferts_Cashiers_ToCashierId",
                        column: x => x.ToCashierId,
                        principalTable: "Cashiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transferts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_BankId",
                table: "Bills",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_BusinessUnitId",
                table: "Bills",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_CashierId",
                table: "Bills",
                column: "CashierId");

            migrationBuilder.CreateIndex(
                name: "IX_Cashiers_BusinessUnitId",
                table: "Cashiers",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BillId",
                table: "Payments",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PartnerId",
                table: "Payments",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferts_FromBankId",
                table: "Transferts",
                column: "FromBankId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferts_FromCashierId",
                table: "Transferts",
                column: "FromCashierId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferts_ToBankId",
                table: "Transferts",
                column: "ToBankId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferts_ToCashierId",
                table: "Transferts",
                column: "ToCashierId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferts_UserId",
                table: "Transferts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Banks_BankId",
                table: "Bills",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_BusinessUnits_BusinessUnitId",
                table: "Bills",
                column: "BusinessUnitId",
                principalTable: "BusinessUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Cashiers_CashierId",
                table: "Bills",
                column: "CashierId",
                principalTable: "Cashiers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Banks_BankId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_BusinessUnits_BusinessUnitId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Cashiers_CashierId",
                table: "Bills");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Transferts");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Cashiers");

            migrationBuilder.DropIndex(
                name: "IX_Bills_BankId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_BusinessUnitId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_CashierId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "BusinessUnitId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "CashierId",
                table: "Bills");
        }
    }
}
