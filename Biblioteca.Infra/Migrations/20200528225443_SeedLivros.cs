using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Infra.Migrations
{
    public partial class SeedLivros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Livro",
                table: "Livro",
                columns: new[] { "Id", "Ano", "Descricao", "Serial", "Situacao", "SubTitulo", "Titulo" },
                values: new object[,]
                {
                    { 1, 2002, "", "0000000001", 0, null, "Agile Software Development, Principles, Patterns, and Practices" },
                    { 2, 2009, "", "0000000002", 0, "A Handbook of Agile Software Craftsmanship", "Clean Code" },
                    { 3, 2011, "", "0000000003", 0, "A Code Of Conduct For Professional Programmers", "The Clean Coder" },
                    { 4, 2017, "", "0000000004", 0, "A Craftsman's Guide to Software Structure and Design", "Clean Architecture" },
                    { 5, 2019, "", "0000000005", 0, "Back to Basics", "Clean Agile" },
                    { 6, 2003, "", "0000000006", 0, "Tackling Complexity in the Heart of Software", "Domain-Driven Design" },
                    { 7, 2013, "", "0000000007", 0, null, "Implementing Domain-Driven Design" },
                    { 8, 2016, "", "0000000008", 0, null, "Domain-Driven Design Distilled" }
                });

            migrationBuilder.InsertData(
                schema: "Livro",
                table: "LivroAutor",
                columns: new[] { "Id", "AutorId", "LivroId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 1, 4 },
                    { 5, 1, 5 },
                    { 6, 2, 6 },
                    { 7, 3, 7 },
                    { 8, 3, 8 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Livro",
                table: "LivroAutor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Livro",
                table: "LivroAutor",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Livro",
                table: "LivroAutor",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Livro",
                table: "LivroAutor",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Livro",
                table: "LivroAutor",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Livro",
                table: "LivroAutor",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Livro",
                table: "LivroAutor",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Livro",
                table: "LivroAutor",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Livro",
                table: "Livro",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Livro",
                table: "Livro",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Livro",
                table: "Livro",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Livro",
                table: "Livro",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Livro",
                table: "Livro",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Livro",
                table: "Livro",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Livro",
                table: "Livro",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Livro",
                table: "Livro",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
