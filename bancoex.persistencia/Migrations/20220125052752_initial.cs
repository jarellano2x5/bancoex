using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bancoex.persistencia.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Identificacion = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", unicode: false, maxLength: 200, nullable: false),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblCuenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumeroCuenta = table.Column<string>(type: "TEXT", unicode: false, maxLength: 18, nullable: false),
                    Saldo = table.Column<float>(type: "REAL", nullable: false),
                    Tipo = table.Column<int>(type: "INTEGER", nullable: false),
                    Activa = table.Column<bool>(type: "INTEGER", nullable: false),
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCuenta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuenta_Cliente",
                        column: x => x.IdCliente,
                        principalTable: "tblCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblMovimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Saldo = table.Column<float>(type: "REAL", nullable: false),
                    Importe = table.Column<float>(type: "REAL", nullable: false),
                    Tipo = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdCuenta = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMovimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimiento_Cuenta",
                        column: x => x.IdCuenta,
                        principalTable: "tblCuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCuenta_IdCliente",
                table: "tblCuenta",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovimiento_IdCuenta",
                table: "tblMovimiento",
                column: "IdCuenta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblMovimiento");

            migrationBuilder.DropTable(
                name: "tblCuenta");

            migrationBuilder.DropTable(
                name: "tblCliente");
        }
    }
}
