using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyect_alfabet_7._0.Migrations
{
    /// <inheritdoc />
    public partial class ChangesToRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Content_Progress_ProgressId",
                table: "Content");

            migrationBuilder.DropIndex(
                name: "IX_Content_ProgressId",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "ProgressId",
                table: "Content");

            migrationBuilder.AddColumn<int>(
                name: "LastDoneContent",
                table: "Progress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LessonsQuantity",
                table: "Modules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContentQuantity",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastDoneContent",
                table: "Progress");

            migrationBuilder.DropColumn(
                name: "LessonsQuantity",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "ContentQuantity",
                table: "Lessons");

            migrationBuilder.AddColumn<int>(
                name: "ProgressId",
                table: "Content",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Content_ProgressId",
                table: "Content",
                column: "ProgressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Content_Progress_ProgressId",
                table: "Content",
                column: "ProgressId",
                principalTable: "Progress",
                principalColumn: "Id");
        }
    }
}
