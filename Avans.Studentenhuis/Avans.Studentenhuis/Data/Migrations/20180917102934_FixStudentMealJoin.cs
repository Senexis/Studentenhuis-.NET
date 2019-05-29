using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Avans.Studentenhuis.Data.Migrations
{
    public partial class FixStudentMealJoin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Meals_MealId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_MealId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Meals");

            migrationBuilder.AddColumn<Guid>(
                name: "MealId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MealId",
                table: "AspNetUsers",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Meals_MealId",
                table: "AspNetUsers",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Meals_MealId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MealId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "MealId",
                table: "Meals",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MealId",
                table: "Meals",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Meals_MealId",
                table: "Meals",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
