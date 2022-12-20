using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _28Exam1.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Posts_PostId",
                table: "Associations");

            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Users_UserId",
                table: "Associations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Associations",
                table: "Associations");

            migrationBuilder.RenameTable(
                name: "Associations",
                newName: "Association");

            migrationBuilder.RenameIndex(
                name: "IX_Associations_UserId",
                table: "Association",
                newName: "IX_Association_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Associations_PostId",
                table: "Association",
                newName: "IX_Association_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Association",
                table: "Association",
                column: "AssociationId");

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    LikeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.LikeId);
                    table.ForeignKey(
                        name: "FK_Likes_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PostId",
                table: "Likes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Association_Posts_PostId",
                table: "Association",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Association_Users_UserId",
                table: "Association",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Association_Posts_PostId",
                table: "Association");

            migrationBuilder.DropForeignKey(
                name: "FK_Association_Users_UserId",
                table: "Association");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Association",
                table: "Association");

            migrationBuilder.RenameTable(
                name: "Association",
                newName: "Associations");

            migrationBuilder.RenameIndex(
                name: "IX_Association_UserId",
                table: "Associations",
                newName: "IX_Associations_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Association_PostId",
                table: "Associations",
                newName: "IX_Associations_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Associations",
                table: "Associations",
                column: "AssociationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Associations_Posts_PostId",
                table: "Associations",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Associations_Users_UserId",
                table: "Associations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
