using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Infra.Migrations
{
    public partial class SeedAutores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
