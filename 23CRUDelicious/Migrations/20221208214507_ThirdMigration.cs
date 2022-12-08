using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _23CRUDelicious.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dishs",
                table: "Dishs");

            migrationBuilder.RenameTable(
                name: "Dishs",
                newName: "Dishes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes",
                column: "DishId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes");

            migrationBuilder.RenameTable(
                name: "Dishes",
                newName: "Dishs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dishs",
                table: "Dishs",
                column: "DishId");
        }
    }
}
