using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Infra.Migrations
{
    public partial class AddUniqueIndexEmLivroAutor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LivroAutor_AutorId",
                schema: "Livro",
                table: "LivroAutor");

            migrationBuilder.CreateIndex(
                name: "IX_LivroAutor_AutorId_LivroId",
                schema: "Livro",
                table: "LivroAutor",
                columns: new[] { "AutorId", "LivroId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LivroAutor_AutorId_LivroId",
                schema: "Livro",
                table: "LivroAutor");

            migrationBuilder.CreateIndex(
                name: "IX_LivroAutor_AutorId",
                schema: "Livro",
                table: "LivroAutor",
                column: "AutorId");
        }
    }
}
