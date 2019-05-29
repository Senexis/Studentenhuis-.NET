using Microsoft.EntityFrameworkCore.Migrations;

namespace Avans.Studentenhuis.Data.Migrations
{
    public partial class AddMealCookForeign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CookId",
                table: "Meals",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_CookId",
                table: "Meals",
                column: "CookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_AspNetUsers_CookId",
                table: "Meals",
                column: "CookId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_AspNetUsers_CookId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_CookId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "CookId",
                table: "Meals");
        }
    }
}
