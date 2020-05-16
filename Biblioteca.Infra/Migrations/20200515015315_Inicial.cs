using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Infra.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 300, nullable: false),
                    Serial = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 5000, nullable: false),
                    Situacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataLocacao = table.Column<DateTime>(nullable: false),
                    DataPrevistaDevolucao = table.Column<DateTime>(nullable: false),
                    DataDevolucao = table.Column<DateTime>(nullable: true),
                    ClienteId = table.Column<int>(nullable: false),
                    TeveMulta = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locacao_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 300, nullable: false),
                    LivroId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Autor_Livro_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Livro1",
                columns: table => new
                {
                    LivroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocacaoId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Serial = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro1", x => new { x.LocacaoId, x.LivroId });
                    table.ForeignKey(
                        name: "FK_Livro1_Locacao_LocacaoId",
                        column: x => x.LocacaoId,
                        principalTable: "Locacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autor_LivroId",
                table: "Autor",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_Locacao_ClienteId",
                table: "Locacao",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Livro1");

            migrationBuilder.DropTable(
                name: "Livro");

            migrationBuilder.DropTable(
                name: "Locacao");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
