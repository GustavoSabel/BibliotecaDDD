using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Infra.Migrations
{
    public partial class Correcao_livro_autor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autor_Livro_LivroId",
                table: "Autor");

            migrationBuilder.DropIndex(
                name: "IX_Autor_LivroId",
                table: "Autor");

            migrationBuilder.DropColumn(
                name: "LivroId",
                table: "Autor");

            migrationBuilder.CreateTable(
                name: "LivroAutor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutorId = table.Column<int>(nullable: false),
                    LivroId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroAutor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LivroAutor_Autor_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroAutor_Livro_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LivroAutor_AutorId",
                table: "LivroAutor",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_LivroAutor_LivroId",
                table: "LivroAutor",
                column: "LivroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivroAutor");

            migrationBuilder.AddColumn<int>(
                name: "LivroId",
                table: "Autor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Autor_LivroId",
                table: "Autor",
                column: "LivroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autor_Livro_LivroId",
                table: "Autor",
                column: "LivroId",
                principalTable: "Livro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
