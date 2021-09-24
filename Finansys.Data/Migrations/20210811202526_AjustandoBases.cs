using Microsoft.EntityFrameworkCore.Migrations;

namespace Finansys.Data.Migrations
{
    public partial class AjustandoBases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaOrcamento_ControleOrcamentarioDTOs_OrcamentoDTOCont~",
                table: "CategoriaOrcamento");

            migrationBuilder.DropIndex(
                name: "IX_CategoriaOrcamento_OrcamentoDTOControleOrcamentarioId",
                table: "CategoriaOrcamento");

            migrationBuilder.DropColumn(
                name: "OrcamentoDTOControleOrcamentarioId",
                table: "CategoriaOrcamento");

            migrationBuilder.AlterColumn<string>(
                name: "OrcamentoId",
                table: "CategoriaOrcamento",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaOrcamento_OrcamentoId",
                table: "CategoriaOrcamento",
                column: "OrcamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaOrcamento_ControleOrcamentarioDTOs_OrcamentoId",
                table: "CategoriaOrcamento",
                column: "OrcamentoId",
                principalTable: "ControleOrcamentarioDTOs",
                principalColumn: "ControleOrcamentarioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaOrcamento_ControleOrcamentarioDTOs_OrcamentoId",
                table: "CategoriaOrcamento");

            migrationBuilder.DropIndex(
                name: "IX_CategoriaOrcamento_OrcamentoId",
                table: "CategoriaOrcamento");

            migrationBuilder.AlterColumn<string>(
                name: "OrcamentoId",
                table: "CategoriaOrcamento",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "OrcamentoDTOControleOrcamentarioId",
                table: "CategoriaOrcamento",
                type: "varchar(50)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaOrcamento_OrcamentoDTOControleOrcamentarioId",
                table: "CategoriaOrcamento",
                column: "OrcamentoDTOControleOrcamentarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaOrcamento_ControleOrcamentarioDTOs_OrcamentoDTOCont~",
                table: "CategoriaOrcamento",
                column: "OrcamentoDTOControleOrcamentarioId",
                principalTable: "ControleOrcamentarioDTOs",
                principalColumn: "ControleOrcamentarioId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
