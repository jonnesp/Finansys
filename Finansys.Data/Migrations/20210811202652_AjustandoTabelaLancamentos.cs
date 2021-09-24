using Microsoft.EntityFrameworkCore.Migrations;

namespace Finansys.Data.Migrations
{
    public partial class AjustandoTabelaLancamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Lancamentos_ControleOrcamentarioDTOs_ControleOrcamentario~",
                table: "Tb_Lancamentos");

            migrationBuilder.DropIndex(
                name: "IX_Tb_Lancamentos_ControleOrcamentarioDTOControleOrcamentarioId",
                table: "Tb_Lancamentos");

            migrationBuilder.DropColumn(
                name: "ControleOrcamentarioDTOControleOrcamentarioId",
                table: "Tb_Lancamentos");

            migrationBuilder.AlterColumn<string>(
                name: "ControleOrcamentarioId",
                table: "Tb_Lancamentos",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Lancamentos_ControleOrcamentarioId",
                table: "Tb_Lancamentos",
                column: "ControleOrcamentarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Lancamentos_ControleOrcamentarioDTOs_ControleOrcamentario~",
                table: "Tb_Lancamentos",
                column: "ControleOrcamentarioId",
                principalTable: "ControleOrcamentarioDTOs",
                principalColumn: "ControleOrcamentarioId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Lancamentos_ControleOrcamentarioDTOs_ControleOrcamentario~",
                table: "Tb_Lancamentos");

            migrationBuilder.DropIndex(
                name: "IX_Tb_Lancamentos_ControleOrcamentarioId",
                table: "Tb_Lancamentos");

            migrationBuilder.AlterColumn<string>(
                name: "ControleOrcamentarioId",
                table: "Tb_Lancamentos",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ControleOrcamentarioDTOControleOrcamentarioId",
                table: "Tb_Lancamentos",
                type: "varchar(50)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Lancamentos_ControleOrcamentarioDTOControleOrcamentarioId",
                table: "Tb_Lancamentos",
                column: "ControleOrcamentarioDTOControleOrcamentarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Lancamentos_ControleOrcamentarioDTOs_ControleOrcamentario~",
                table: "Tb_Lancamentos",
                column: "ControleOrcamentarioDTOControleOrcamentarioId",
                principalTable: "ControleOrcamentarioDTOs",
                principalColumn: "ControleOrcamentarioId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
