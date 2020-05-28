using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Infra.Migrations
{
    public partial class EditLivro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Nome",
                schema: "Livro",
                table: "Livro");

            migrationBuilder.AddColumn<int>(
                name: "Ano",
                schema: "Livro",
                table: "Livro",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SubTitulo",
                schema: "Livro",
                table: "Livro",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                schema: "Livro",
                table: "Livro",
                maxLength: 300,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ano",
                schema: "Livro",
                table: "Livro");

            migrationBuilder.DropColumn(
                name: "SubTitulo",
                schema: "Livro",
                table: "Livro");

            migrationBuilder.DropColumn(
                name: "Titulo",
                schema: "Livro",
                table: "Livro");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                schema: "Livro",
                table: "Livro",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                schema: "Livro",
                table: "Autor",
                columns: new[] { "Id", "DataNascimento", "Nome" },
                values: new object[,]
                {
                    { 1, new DateTime(1500, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Cecil Martin" },
                    { 2, new DateTime(1600, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eric Evans" },
                    { 3, new DateTime(1700, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "vaughn vernon" },
                    { 4, new DateTime(1800, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Erich Gamma" },
                    { 5, new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Vlissides" },
                    { 6, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Richard Helm" },
                    { 7, new DateTime(1975, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ralph Johnson" }
                });
        }
    }
}
