using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgramlamaProje.Data.Migrations
{
    public partial class _2122 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmOyuncu_Filmler_FilmID",
                table: "FilmOyuncu");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmOyuncu_Oyuncular_OyuncuID",
                table: "FilmOyuncu");

            migrationBuilder.DropForeignKey(
                name: "FK_Oyuncular_Filmler_FilmID",
                table: "Oyuncular");

            migrationBuilder.DropIndex(
                name: "IX_Oyuncular_FilmID",
                table: "Oyuncular");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmOyuncu",
                table: "FilmOyuncu");

            migrationBuilder.DropIndex(
                name: "IX_FilmOyuncu_FilmID",
                table: "FilmOyuncu");

            migrationBuilder.DropColumn(
                name: "FilmID",
                table: "Oyuncular");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmOyuncu_Filmler_FilmlerFilmID",
                table: "FilmOyuncu");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmOyuncu_Oyuncular_OyuncularOyuncuID",
                table: "FilmOyuncu");

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
                name: "FilmID",
                table: "Oyuncular",
                type: "int",
                nullable: true);

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
                name: "IX_Oyuncular_FilmID",
                table: "Oyuncular",
                column: "FilmID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Oyuncular_Filmler_FilmID",
                table: "Oyuncular",
                column: "FilmID",
                principalTable: "Filmler",
                principalColumn: "FilmID");
        }
    }
}
