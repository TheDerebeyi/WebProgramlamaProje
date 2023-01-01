using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgramlamaProje.Data.Migrations
{
    public partial class _0203 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "YonetmenCinsiyet",
                table: "Yonetmenler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OyuncuCinsiyet",
                table: "Oyuncular",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YonetmenCinsiyet",
                table: "Yonetmenler");

            migrationBuilder.DropColumn(
                name: "OyuncuCinsiyet",
                table: "Oyuncular");
        }
    }
}
