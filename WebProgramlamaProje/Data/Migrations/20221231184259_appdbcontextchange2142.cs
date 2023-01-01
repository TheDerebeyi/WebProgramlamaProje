using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgramlamaProje.Data.Migrations
{
    public partial class appdbcontextchange2142 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmOyuncu_Filmler_FilmlerFilmID",
                table: "FilmOyuncu");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmOyuncu_Oyuncular_OyuncularOyuncuID",
                table: "FilmOyuncu");

            migrationBuilder.DropTable(
                name: "FilmOyuncular");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmOyuncu",
                table: "FilmOyuncu");

            migrationBuilder.RenameColumn(
                name: "OyuncularOyuncuID",
                table: "FilmOyuncu",
                newName: "OyuncuID");

            migrationBuilder.RenameColumn(
                name: "FilmlerFilmID",
                table: "FilmOyuncu",
                newName: "FilmID");

            migrationBuilder.RenameIndex(
                name: "IX_FilmOyuncu_OyuncularOyuncuID",
                table: "FilmOyuncu",
                newName: "IX_FilmOyuncu_OyuncuID");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FilmOyuncu",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmOyuncu",
                table: "FilmOyuncu",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FilmOyuncu_FilmID",
                table: "FilmOyuncu",
                column: "FilmID");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmOyuncu_Filmler_FilmID",
                table: "FilmOyuncu",
                column: "FilmID",
                principalTable: "Filmler",
                principalColumn: "FilmID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmOyuncu_Oyuncular_OyuncuID",
                table: "FilmOyuncu",
                column: "OyuncuID",
                principalTable: "Oyuncular",
                principalColumn: "OyuncuID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmOyuncu_Filmler_FilmID",
                table: "FilmOyuncu");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmOyuncu_Oyuncular_OyuncuID",
                table: "FilmOyuncu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmOyuncu",
                table: "FilmOyuncu");

            migrationBuilder.DropIndex(
                name: "IX_FilmOyuncu_FilmID",
                table: "FilmOyuncu");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FilmOyuncu");

            migrationBuilder.RenameColumn(
                name: "OyuncuID",
                table: "FilmOyuncu",
                newName: "OyuncularOyuncuID");

            migrationBuilder.RenameColumn(
                name: "FilmID",
                table: "FilmOyuncu",
                newName: "FilmlerFilmID");

            migrationBuilder.RenameIndex(
                name: "IX_FilmOyuncu_OyuncuID",
                table: "FilmOyuncu",
                newName: "IX_FilmOyuncu_OyuncularOyuncuID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmOyuncu",
                table: "FilmOyuncu",
                columns: new[] { "FilmlerFilmID", "OyuncularOyuncuID" });

            migrationBuilder.CreateTable(
                name: "FilmOyuncular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmID = table.Column<int>(type: "int", nullable: false),
                    OyuncuID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmOyuncular", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmOyuncular_Filmler_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Filmler",
                        principalColumn: "FilmID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmOyuncular_Oyuncular_OyuncuID",
                        column: x => x.OyuncuID,
                        principalTable: "Oyuncular",
                        principalColumn: "OyuncuID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmOyuncular_FilmID",
                table: "FilmOyuncular",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_FilmOyuncular_OyuncuID",
                table: "FilmOyuncular",
                column: "OyuncuID");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmOyuncu_Filmler_FilmlerFilmID",
                table: "FilmOyuncu",
                column: "FilmlerFilmID",
                principalTable: "Filmler",
                principalColumn: "FilmID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmOyuncu_Oyuncular_OyuncularOyuncuID",
                table: "FilmOyuncu",
                column: "OyuncularOyuncuID",
                principalTable: "Oyuncular",
                principalColumn: "OyuncuID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
