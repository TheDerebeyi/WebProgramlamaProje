using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgramlamaProje.Data.Migrations
{
    public partial class _2320 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_RolId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RolId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "AspNetUsers");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "RolId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RolId",
                table: "AspNetUsers",
                column: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_RolId",
                table: "AspNetUsers",
                column: "RolId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");
        }
    }
}
