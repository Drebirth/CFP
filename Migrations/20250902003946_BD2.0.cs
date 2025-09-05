using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CFP.Migrations
{
    /// <inheritdoc />
    public partial class BD20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdConta",
                table: "Despesas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdConta",
                table: "Despesas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
