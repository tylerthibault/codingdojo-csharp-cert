using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _23CRUDelicious.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Calories",
                table: "Dishs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Chef",
                table: "Dishs",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Dishs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Dishs",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Tastiness",
                table: "Dishs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Dishs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calories",
                table: "Dishs");

            migrationBuilder.DropColumn(
                name: "Chef",
                table: "Dishs");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Dishs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Dishs");

            migrationBuilder.DropColumn(
                name: "Tastiness",
                table: "Dishs");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Dishs");
        }
    }
}
