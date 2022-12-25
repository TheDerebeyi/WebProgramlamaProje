using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgramlamaProje.Data.Migrations
{
    public partial class _2612220240 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilmlerFilmID",
                table: "FilmOyuncu");

            migrationBuilder.DropColumn(
                name: "OyuncularOyuncuID",
                table: "FilmOyuncu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FilmlerFilmID",
                table: "FilmOyuncu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OyuncularOyuncuID",
                table: "FilmOyuncu",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
