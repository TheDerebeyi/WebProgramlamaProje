using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgramlamaProje.Data.Migrations
{
    public partial class _2313 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
