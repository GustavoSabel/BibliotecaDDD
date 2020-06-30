using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Infra.Migrations
{
    public partial class RetirarDeleteCascadeAutor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LivroAutor_Autor_AutorId",
                schema: "Livro",
                table: "LivroAutor");

            migrationBuilder.AddForeignKey(
                name: "FK_LivroAutor_Autor_AutorId",
                schema: "Livro",
                table: "LivroAutor",
                column: "AutorId",
                principalSchema: "Livro",
                principalTable: "Autor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LivroAutor_Autor_AutorId",
                schema: "Livro",
                table: "LivroAutor");

            migrationBuilder.AddForeignKey(
                name: "FK_LivroAutor_Autor_AutorId",
                schema: "Livro",
                table: "LivroAutor",
                column: "AutorId",
                principalSchema: "Livro",
                principalTable: "Autor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
