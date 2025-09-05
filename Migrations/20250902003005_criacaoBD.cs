using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CFP.Migrations
{
    /// <inheritdoc />
    public partial class criacaoBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Salario = table.Column<decimal>(type: "TEXT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalizadorDespesas = table.Column<decimal>(type: "TEXT", nullable: true),
                    TotalizadorSalario = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Despesas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdConta = table.Column<int>(type: "INTEGER", nullable: false),
                    contaId = table.Column<int>(type: "INTEGER", nullable: true),
                    NomeDespesa = table.Column<string>(type: "TEXT", nullable: false),
                    ValorDespesa = table.Column<decimal>(type: "TEXT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataDespesa = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TotalizadorDespesasMensal = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Despesas_Contas_contaId",
                        column: x => x.contaId,
                        principalTable: "Contas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_contaId",
                table: "Despesas",
                column: "contaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Despesas");

            migrationBuilder.DropTable(
                name: "Contas");
        }
    }
}
