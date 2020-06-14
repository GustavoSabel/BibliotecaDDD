using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Infra.Migrations
{
    public partial class AddEstadoLivro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Estado");

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                schema: "Livro",
                table: "Livro",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Livro",
                schema: "Estado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Estado",
                table: "Livro",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 1, "Ótimo" });

            migrationBuilder.InsertData(
                schema: "Estado",
                table: "Livro",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 2, "Bom" });

            migrationBuilder.InsertData(
                schema: "Estado",
                table: "Livro",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 3, "Ruim" });

            migrationBuilder.UpdateData(
                schema: "Livro",
                table: "Livro",
                keyColumn: "Id",
                keyValue: 1,
                column: "EstadoId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Livro",
                table: "Livro",
                keyColumn: "Id",
                keyValue: 2,
                column: "EstadoId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Livro",
                table: "Livro",
                keyColumn: "Id",
                keyValue: 3,
                column: "EstadoId",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "Livro",
                table: "Livro",
                keyColumn: "Id",
                keyValue: 4,
                column: "EstadoId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "Livro",
                table: "Livro",
                keyColumn: "Id",
                keyValue: 5,
                column: "EstadoId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Livro",
                table: "Livro",
                keyColumn: "Id",
                keyValue: 6,
                column: "EstadoId",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "Livro",
                table: "Livro",
                keyColumn: "Id",
                keyValue: 7,
                column: "EstadoId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "Livro",
                table: "Livro",
                keyColumn: "Id",
                keyValue: 8,
                column: "EstadoId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Livro_EstadoId",
                schema: "Livro",
                table: "Livro",
                column: "EstadoId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livro_Livro_EstadoId",
                schema: "Livro",
                table: "Livro");

            migrationBuilder.DropTable(
                name: "Livro",
                schema: "Estado");

            migrationBuilder.DropIndex(
                name: "IX_Livro_EstadoId",
                schema: "Livro",
                table: "Livro");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                schema: "Livro",
                table: "Livro");
        }
    }
}
