using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Infra.Migrations
{
    public partial class Adddatanascimentoautor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                schema: "Livro",
                table: "Autor",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "Livro",
                table: "Autor",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataNascimento",
                value: new DateTime(1500, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "Livro",
                table: "Autor",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataNascimento",
                value: new DateTime(1600, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "Livro",
                table: "Autor",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataNascimento",
                value: new DateTime(1700, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "Livro",
                table: "Autor",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataNascimento",
                value: new DateTime(1800, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "Livro",
                table: "Autor",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataNascimento",
                value: new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "Livro",
                table: "Autor",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataNascimento",
                value: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "Livro",
                table: "Autor",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataNascimento",
                value: new DateTime(1975, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                schema: "Livro",
                table: "Autor");
        }
    }
}
