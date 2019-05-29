using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Avans.Studentenhuis.Data.Migrations
{
    public partial class AddStudentMealJoin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MealId",
                table: "Meals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MealId",
                table: "Meals",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StudentId",
                table: "AspNetUsers",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_StudentId",
                table: "AspNetUsers",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Meals_MealId",
                table: "Meals",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_StudentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Meals_MealId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_MealId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StudentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Meals",
                nullable: false,
                oldClrType: typeof(Guid))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        }
    }
}
