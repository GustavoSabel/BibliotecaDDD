using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Infra.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Livro");

            migrationBuilder.EnsureSchema(
                name: "Locacao");

            migrationBuilder.CreateTable(
                name: "Autor",
                schema: "Livro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                schema: "Livro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                schema: "Locacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Cpf = table.Column<string>(type: "CHAR(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                schema: "Livro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    SubTitulo = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    Ano = table.Column<int>(nullable: false),
                    Serial = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Situacao = table.Column<int>(nullable: false),
                    EstadoId = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(5000)", maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livro_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalSchema: "Livro",
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locacao",
                schema: "Locacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataLocacao = table.Column<DateTime>(nullable: false),
                    DataPrevistaDevolucao = table.Column<DateTime>(nullable: false),
                    DataDevolucao = table.Column<DateTime>(nullable: true),
                    Devolvido = table.Column<bool>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    TeveMulta = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locacao_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalSchema: "Locacao",
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivroAutor",
                schema: "Livro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutorId = table.Column<int>(nullable: false),
                    LivroId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroAutor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LivroAutor_Autor_AutorId",
                        column: x => x.AutorId,
                        principalSchema: "Livro",
                        principalTable: "Autor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroAutor_Livro_LivroId",
                        column: x => x.LivroId,
                        principalSchema: "Livro",
                        principalTable: "Livro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                schema: "Locacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LivroId = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    SubTitulo = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Estado = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    LocacaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livro_Locacao_LocacaoId",
                        column: x => x.LocacaoId,
                        principalSchema: "Locacao",
                        principalTable: "Locacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Livro",
                table: "Autor",
                columns: new[] { "Id", "DataNascimento", "Nome" },
                values: new object[,]
                {
                    { 1, new DateTime(1952, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Cecil Martin" },
                    { 2, new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eric Evans" },
                    { 3, new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vaughn Vernon" },
                    { 4, new DateTime(1961, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Erich Gamma" },
                    { 5, new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Vlissides" },
                    { 6, new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Richard Helm" },
                    { 7, new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ralph Johnson" }
                });

            migrationBuilder.InsertData(
                schema: "Livro",
                table: "Estado",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Ótimo" },
                    { 2, "Bom" },
                    { 3, "Ruim" }
                });

            migrationBuilder.InsertData(
                schema: "Livro",
                table: "Livro",
                columns: new[] { "Id", "Ano", "Descricao", "EstadoId", "Serial", "Situacao", "Titulo", "SubTitulo" },
                values: new object?[,]
                {
                    { 1, 2002, null, 1, "0000000001", 0, "Agile Software Development, Principles, Patterns, and Practices", null },
                    { 2, 2009, null, 1, "0000000002", 0, "Clean Code", "A Handbook of Agile Software Craftsmanship" },
                    { 5, 2019, null, 1, "0000000005", 0, "Clean Agile", "Back to Basics" },
                    { 4, 2017, null, 2, "0000000004", 0, "Clean Architecture", "A Craftsman's Guide to Software Structure and Design" },
                    { 7, 2013, null, 2, "0000000007", 0, "Implementing Domain-Driven Design", null },
                    { 3, 2011, null, 3, "0000000003", 0, "The Clean Coder", "A Code Of Conduct For Professional Programmers" },
                    { 6, 2003, null, 3, "0000000006", 0, "Domain-Driven Design", "Tackling Complexity in the Heart of Software" },
                    { 8, 2016, null, 3, "0000000008", 0, "Domain-Driven Design Distilled", null }
                });

            migrationBuilder.InsertData(
                schema: "Livro",
                table: "LivroAutor",
                columns: new[] { "Id", "AutorId", "LivroId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 5, 1, 5 },
                    { 4, 1, 4 },
                    { 7, 3, 7 },
                    { 3, 1, 3 },
                    { 6, 2, 6 },
                    { 8, 3, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livro_EstadoId",
                schema: "Livro",
                table: "Livro",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_LivroAutor_AutorId",
                schema: "Livro",
                table: "LivroAutor",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_LivroAutor_LivroId",
                schema: "Livro",
                table: "LivroAutor",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_LocacaoId",
                schema: "Locacao",
                table: "Livro",
                column: "LocacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Locacao_ClienteId",
                schema: "Locacao",
                table: "Locacao",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivroAutor",
                schema: "Livro");

            migrationBuilder.DropTable(
                name: "Livro",
                schema: "Locacao");

            migrationBuilder.DropTable(
                name: "Autor",
                schema: "Livro");

            migrationBuilder.DropTable(
                name: "Livro",
                schema: "Livro");

            migrationBuilder.DropTable(
                name: "Locacao",
                schema: "Locacao");

            migrationBuilder.DropTable(
                name: "Estado",
                schema: "Livro");

            migrationBuilder.DropTable(
                name: "Cliente",
                schema: "Locacao");
        }
    }
}
