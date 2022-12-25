using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgramlamaProje.Data.Migrations
{
    public partial class oyuncuYonetmenChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "YonetmenYas",
                table: "Yonetmenler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OyuncuYas",
                table: "Oyuncular",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FilmCikis",
                table: "Filmler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YonetmenYas",
                table: "Yonetmenler");

            migrationBuilder.DropColumn(
                name: "OyuncuYas",
                table: "Oyuncular");

            migrationBuilder.DropColumn(
                name: "FilmCikis",
                table: "Filmler");
        }
    }
}
