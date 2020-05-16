using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Infra.Migrations
{
    public partial class Addschemas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livro_Autor_AutorId",
                schema: "LivroAutor",
                table: "Livro");

            migrationBuilder.DropForeignKey(
                name: "FK_Livro_Livro_LivroId",
                schema: "LivroAutor",
                table: "Livro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Livro",
                schema: "LivroAutor",
                table: "Livro");

            migrationBuilder.RenameTable(
                name: "Livro",
                schema: "LivroAutor",
                newName: "LivroAutor",
                newSchema: "Livro");

            migrationBuilder.RenameIndex(
                name: "IX_Livro_LivroId",
                schema: "Livro",
                table: "LivroAutor",
                newName: "IX_LivroAutor_LivroId");

            migrationBuilder.RenameIndex(
                name: "IX_Livro_AutorId",
                schema: "Livro",
                table: "LivroAutor",
                newName: "IX_LivroAutor_AutorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LivroAutor",
                schema: "Livro",
                table: "LivroAutor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LivroAutor_Autor_AutorId",
                schema: "Livro",
                table: "LivroAutor",
                column: "AutorId",
                principalSchema: "Livro",
                principalTable: "Autor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LivroAutor_Livro_LivroId",
                schema: "Livro",
                table: "LivroAutor",
                column: "LivroId",
                principalSchema: "Livro",
                principalTable: "Livro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LivroAutor_Autor_AutorId",
                schema: "Livro",
                table: "LivroAutor");

            migrationBuilder.DropForeignKey(
                name: "FK_LivroAutor_Livro_LivroId",
                schema: "Livro",
                table: "LivroAutor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LivroAutor",
                schema: "Livro",
                table: "LivroAutor");

            migrationBuilder.EnsureSchema(
                name: "LivroAutor");

            migrationBuilder.RenameTable(
                name: "LivroAutor",
                schema: "Livro",
                newName: "Livro",
                newSchema: "LivroAutor");

            migrationBuilder.RenameIndex(
                name: "IX_LivroAutor_LivroId",
                schema: "LivroAutor",
                table: "Livro",
                newName: "IX_Livro_LivroId");

            migrationBuilder.RenameIndex(
                name: "IX_LivroAutor_AutorId",
                schema: "LivroAutor",
                table: "Livro",
                newName: "IX_Livro_AutorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Livro",
                schema: "LivroAutor",
                table: "Livro",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Livro_Autor_AutorId",
                schema: "LivroAutor",
                table: "Livro",
                column: "AutorId",
                principalSchema: "Livro",
                principalTable: "Autor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Livro_Livro_LivroId",
                schema: "LivroAutor",
                table: "Livro",
                column: "LivroId",
                principalSchema: "Livro",
                principalTable: "Livro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
