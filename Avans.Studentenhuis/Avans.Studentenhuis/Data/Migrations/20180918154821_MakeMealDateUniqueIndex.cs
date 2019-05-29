using Microsoft.EntityFrameworkCore.Migrations;

namespace Avans.Studentenhuis.Data.Migrations
{
    public partial class MakeMealDateUniqueIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Meals_DateTime",
                table: "Meals",
                column: "DateTime",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Meals_DateTime",
                table: "Meals");
        }
    }
}
