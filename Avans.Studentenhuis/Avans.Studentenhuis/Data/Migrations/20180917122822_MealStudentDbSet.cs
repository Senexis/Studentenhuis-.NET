using Microsoft.EntityFrameworkCore.Migrations;

namespace Avans.Studentenhuis.Data.Migrations
{
    public partial class MealStudentDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealStudent_Meals_MealId",
                table: "MealStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_MealStudent_AspNetUsers_StudentId",
                table: "MealStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealStudent",
                table: "MealStudent");

            migrationBuilder.RenameTable(
                name: "MealStudent",
                newName: "MealStudents");

            migrationBuilder.RenameIndex(
                name: "IX_MealStudent_MealId",
                table: "MealStudents",
                newName: "IX_MealStudents_MealId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealStudents",
                table: "MealStudents",
                columns: new[] { "StudentId", "MealId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MealStudents_Meals_MealId",
                table: "MealStudents",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MealStudents_AspNetUsers_StudentId",
                table: "MealStudents",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealStudents_Meals_MealId",
                table: "MealStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_MealStudents_AspNetUsers_StudentId",
                table: "MealStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealStudents",
                table: "MealStudents");

            migrationBuilder.RenameTable(
                name: "MealStudents",
                newName: "MealStudent");

            migrationBuilder.RenameIndex(
                name: "IX_MealStudents_MealId",
                table: "MealStudent",
                newName: "IX_MealStudent_MealId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealStudent",
                table: "MealStudent",
                columns: new[] { "StudentId", "MealId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MealStudent_Meals_MealId",
                table: "MealStudent",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealStudent_AspNetUsers_StudentId",
                table: "MealStudent",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
