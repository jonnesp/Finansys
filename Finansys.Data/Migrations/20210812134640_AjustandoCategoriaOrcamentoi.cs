using Microsoft.EntityFrameworkCore.Migrations;

namespace Finansys.Data.Migrations
{
    public partial class AjustandoCategoriaOrcamentoi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "SaldoDisponivel",
                table: "CategoriaOrcamento",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ValorCreditado",
                table: "CategoriaOrcamento",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaldoDisponivel",
                table: "CategoriaOrcamento");

            migrationBuilder.DropColumn(
                name: "ValorCreditado",
                table: "CategoriaOrcamento");
        }
    }
}
