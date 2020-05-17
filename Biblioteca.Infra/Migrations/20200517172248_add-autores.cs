using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Infra.Migrations
{
    public partial class addautores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Livro",
                table: "Autor",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Robert Cecil Martin" },
                    { 2, "Eric Evans" },
                    { 3, "vaughn vernon" },
                    { 4, "Erich Gamma" },
                    { 5, "John Vlissides" },
                    { 6, "Richard Helm" },
                    { 7, "Ralph Johnson" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Livro",
                table: "Autor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Livro",
                table: "Autor",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Livro",
                table: "Autor",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Livro",
                table: "Autor",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Livro",
                table: "Autor",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Livro",
                table: "Autor",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Livro",
                table: "Autor",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
