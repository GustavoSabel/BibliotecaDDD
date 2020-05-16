using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Infra.Migrations
{
    public partial class Addschemas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LivroAutor_Autor_AutorId",
                table: "LivroAutor");

            migrationBuilder.DropForeignKey(
                name: "FK_LivroAutor_Livro_LivroId",
                table: "LivroAutor");

            migrationBuilder.DropTable(
                name: "Livro1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Livro",
                table: "Livro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LivroAutor",
                table: "LivroAutor");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Livro");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Livro");

            migrationBuilder.DropColumn(
                name: "Situacao",
                table: "Livro");

            migrationBuilder.EnsureSchema(
                name: "Livro");

            migrationBuilder.EnsureSchema(
                name: "LivroAutor");

            migrationBuilder.EnsureSchema(
                name: "Locacao");

            migrationBuilder.RenameTable(
                name: "Locacao",
                newName: "Locacao",
                newSchema: "Locacao");

            migrationBuilder.RenameTable(
                name: "Livro",
                newName: "Livro",
                newSchema: "Locacao");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "Cliente",
                newSchema: "Locacao");

            migrationBuilder.RenameTable(
                name: "Autor",
                newName: "Autor",
                newSchema: "Livro");

            migrationBuilder.RenameTable(
                name: "LivroAutor",
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

            migrationBuilder.AlterColumn<string>(
                name: "Serial",
                schema: "Locacao",
                table: "Livro",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                schema: "Locacao",
                table: "Livro",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AddColumn<int>(
                name: "LocacaoId",
                schema: "Locacao",
                table: "Livro",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LivroId",
                schema: "Locacao",
                table: "Livro",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Livro",
                schema: "Locacao",
                table: "Livro",
                columns: new[] { "LocacaoId", "LivroId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Livro",
                schema: "LivroAutor",
                table: "Livro",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Livro",
                schema: "Livro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 300, nullable: false),
                    Serial = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 5000, nullable: false),
                    Situacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.Id);
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Livro_Locacao_LocacaoId",
                schema: "Locacao",
                table: "Livro",
                column: "LocacaoId",
                principalSchema: "Locacao",
                principalTable: "Locacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livro_Autor_AutorId",
                schema: "LivroAutor",
                table: "Livro");

            migrationBuilder.DropForeignKey(
                name: "FK_Livro_Livro_LivroId",
                schema: "LivroAutor",
                table: "Livro");

            migrationBuilder.DropForeignKey(
                name: "FK_Livro_Locacao_LocacaoId",
                schema: "Locacao",
                table: "Livro");

            migrationBuilder.DropTable(
                name: "Livro",
                schema: "Livro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Livro",
                schema: "Locacao",
                table: "Livro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Livro",
                schema: "LivroAutor",
                table: "Livro");

            migrationBuilder.DropColumn(
                name: "LocacaoId",
                schema: "Locacao",
                table: "Livro");

            migrationBuilder.DropColumn(
                name: "LivroId",
                schema: "Locacao",
                table: "Livro");

            migrationBuilder.RenameTable(
                name: "Locacao",
                schema: "Locacao",
                newName: "Locacao");

            migrationBuilder.RenameTable(
                name: "Livro",
                schema: "Locacao",
                newName: "Livro");

            migrationBuilder.RenameTable(
                name: "Cliente",
                schema: "Locacao",
                newName: "Cliente");

            migrationBuilder.RenameTable(
                name: "Autor",
                schema: "Livro",
                newName: "Autor");

            migrationBuilder.RenameTable(
                name: "Livro",
                schema: "LivroAutor",
                newName: "LivroAutor");

            migrationBuilder.RenameIndex(
                name: "IX_Livro_LivroId",
                table: "LivroAutor",
                newName: "IX_LivroAutor_LivroId");

            migrationBuilder.RenameIndex(
                name: "IX_Livro_AutorId",
                table: "LivroAutor",
                newName: "IX_LivroAutor_AutorId");

            migrationBuilder.AlterColumn<string>(
                name: "Serial",
                table: "Livro",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Livro",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Livro",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Livro",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Situacao",
                table: "Livro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Livro",
                table: "Livro",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LivroAutor",
                table: "LivroAutor",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Livro1",
                columns: table => new
                {
                    LocacaoId = table.Column<int>(type: "int", nullable: false),
                    LivroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Serial = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro1", x => new { x.LocacaoId, x.LivroId });
                    table.ForeignKey(
                        name: "FK_Livro1_Locacao_LocacaoId",
                        column: x => x.LocacaoId,
                        principalTable: "Locacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_LivroAutor_Autor_AutorId",
                table: "LivroAutor",
                column: "AutorId",
                principalTable: "Autor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LivroAutor_Livro_LivroId",
                table: "LivroAutor",
                column: "LivroId",
                principalTable: "Livro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
