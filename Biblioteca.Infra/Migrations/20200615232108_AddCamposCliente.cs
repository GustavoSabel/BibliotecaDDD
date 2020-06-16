using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Infra.Migrations
{
    public partial class AddCamposCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                schema: "Locacao",
                table: "Cliente",
                type: "CHAR(11)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                schema: "Locacao",
                table: "Cliente",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                schema: "Locacao",
                table: "Cliente",
                type: "varchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                schema: "Locacao",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                schema: "Locacao",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Nome",
                schema: "Locacao",
                table: "Cliente");
        }
    }
}
