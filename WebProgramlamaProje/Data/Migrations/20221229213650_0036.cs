using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgramlamaProje.Data.Migrations
{
    public partial class _0036 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_KullaniciId",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_KullaniciId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "KullaniciId",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<string>(
                name: "YonetmenDesc",
                table: "Yonetmenler",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OyuncuDesc",
                table: "Oyuncular",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FilmDesc",
                table: "Filmler",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YonetmenDesc",
                table: "Yonetmenler");

            migrationBuilder.DropColumn(
                name: "OyuncuDesc",
                table: "Oyuncular");

            migrationBuilder.DropColumn(
                name: "FilmDesc",
                table: "Filmler");

            migrationBuilder.AddColumn<string>(
                name: "KullaniciId",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_KullaniciId",
                table: "AspNetRoles",
                column: "KullaniciId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_KullaniciId",
                table: "AspNetRoles",
                column: "KullaniciId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
