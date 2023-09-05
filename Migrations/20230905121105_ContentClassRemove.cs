using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyect_alfabet_7._0.Migrations
{
    /// <inheritdoc />
    public partial class ContentClassRemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Progress_Lessons_LessonId",
                table: "Progress");

            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropIndex(
                name: "IX_Progress_LessonId",
                table: "Progress");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Progress");

            migrationBuilder.DropColumn(
                name: "ContentQuantity",
                table: "Lessons");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Lessons",
                newName: "Url");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Lessons",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "Progress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContentQuantity",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isLast = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Content_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Progress_LessonId",
                table: "Progress",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Content_LessonId",
                table: "Content",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Progress_Lessons_LessonId",
                table: "Progress",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
