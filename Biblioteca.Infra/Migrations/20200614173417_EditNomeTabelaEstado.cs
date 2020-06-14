using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Infra.Migrations
{
    public partial class EditNomeTabelaEstado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livro_Livro_EstadoId",
                schema: "Livro",
                table: "Livro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Livro",
                schema: "Estado",
                table: "Livro");

            migrationBuilder.RenameTable(
                name: "Livro",
                schema: "Estado",
                newName: "Estado",
                newSchema: "Livro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estado",
                schema: "Livro",
                table: "Estado",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Livro_Estado_EstadoId",
                schema: "Livro",
                table: "Livro",
                column: "EstadoId",
                principalSchema: "Livro",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livro_Estado_EstadoId",
                schema: "Livro",
                table: "Livro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estado",
                schema: "Livro",
                table: "Estado");

            migrationBuilder.EnsureSchema(
                name: "Estado");

            migrationBuilder.RenameTable(
                name: "Estado",
                schema: "Livro",
                newName: "Livro",
                newSchema: "Estado");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Livro",
                schema: "Estado",
                table: "Livro",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Livro_Livro_EstadoId",
                schema: "Livro",
                table: "Livro",
                column: "EstadoId",
                principalSchema: "Estado",
                principalTable: "Livro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
