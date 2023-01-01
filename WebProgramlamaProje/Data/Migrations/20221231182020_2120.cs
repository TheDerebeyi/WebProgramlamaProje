using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgramlamaProje.Data.Migrations
{
    public partial class _2120 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FilmID",
                table: "Oyuncular",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Oyuncular_FilmID",
                table: "Oyuncular",
                column: "FilmID");

            migrationBuilder.AddForeignKey(
                name: "FK_Oyuncular_Filmler_FilmID",
                table: "Oyuncular",
                column: "FilmID",
                principalTable: "Filmler",
                principalColumn: "FilmID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oyuncular_Filmler_FilmID",
                table: "Oyuncular");

            migrationBuilder.DropIndex(
                name: "IX_Oyuncular_FilmID",
                table: "Oyuncular");

            migrationBuilder.DropColumn(
                name: "FilmID",
                table: "Oyuncular");
        }
    }
}
