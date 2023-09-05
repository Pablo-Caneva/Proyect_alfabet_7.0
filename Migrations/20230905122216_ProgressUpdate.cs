using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyect_alfabet_7._0.Migrations
{
    /// <inheritdoc />
    public partial class ProgressUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastDoneContent",
                table: "Progress",
                newName: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Progress_LessonId",
                table: "Progress",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Progress_Lessons_LessonId",
                table: "Progress",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Progress_Lessons_LessonId",
                table: "Progress");

            migrationBuilder.DropIndex(
                name: "IX_Progress_LessonId",
                table: "Progress");

            migrationBuilder.RenameColumn(
                name: "LessonId",
                table: "Progress",
                newName: "LastDoneContent");
        }
    }
}
