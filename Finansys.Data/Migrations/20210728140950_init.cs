using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Finansys.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ControleOrcamentarioDTOs",
                columns: table => new
                {
                    ControleOrcamentarioId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Inicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Fim = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MesReferencia = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorMensal = table.Column<double>(type: "double", nullable: false),
                    UsuarioId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Despesa = table.Column<double>(type: "double", nullable: false),
                    Saldo = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControleOrcamentarioDTOs", x => x.ControleOrcamentarioId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tb_Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuarioId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Categorias", x => x.CategoriaId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CategoriaOrcamento",
                columns: table => new
                {
                    CategoriaId = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrcamentoId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrcamentoDTOControleOrcamentarioId = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorLimite = table.Column<double>(type: "double", nullable: false),
                    ValorJaGasto = table.Column<double>(type: "double", nullable: false),
                    UsuarioId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaOrcamento", x => new { x.CategoriaId, x.OrcamentoId });
                    table.ForeignKey(
                        name: "FK_CategoriaOrcamento_ControleOrcamentarioDTOs_OrcamentoDTOCont~",
                        column: x => x.OrcamentoDTOControleOrcamentarioId,
                        principalTable: "ControleOrcamentarioDTOs",
                        principalColumn: "ControleOrcamentarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoriaOrcamento_Tb_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Tb_Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tb_Lancamentos",
                columns: table => new
                {
                    LancamentoId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuarioId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoriaId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoLancamento = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<double>(type: "double", nullable: false),
                    ControleOrcamentarioId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ControleOrcamentarioDTOControleOrcamentarioId = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Lancamentos", x => x.LancamentoId);
                    table.ForeignKey(
                        name: "FK_Tb_Lancamentos_ControleOrcamentarioDTOs_ControleOrcamentario~",
                        column: x => x.ControleOrcamentarioDTOControleOrcamentarioId,
                        principalTable: "ControleOrcamentarioDTOs",
                        principalColumn: "ControleOrcamentarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_Lancamentos_Tb_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Tb_Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaOrcamento_OrcamentoDTOControleOrcamentarioId",
                table: "CategoriaOrcamento",
                column: "OrcamentoDTOControleOrcamentarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Lancamentos_CategoriaId",
                table: "Tb_Lancamentos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Lancamentos_ControleOrcamentarioDTOControleOrcamentarioId",
                table: "Tb_Lancamentos",
                column: "ControleOrcamentarioDTOControleOrcamentarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaOrcamento");

            migrationBuilder.DropTable(
                name: "Tb_Lancamentos");

            migrationBuilder.DropTable(
                name: "ControleOrcamentarioDTOs");

            migrationBuilder.DropTable(
                name: "Tb_Categorias");
        }
    }
}
