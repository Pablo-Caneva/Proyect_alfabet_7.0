using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyect_alfabet_7._0.Migrations
{
    /// <inheritdoc />
    public partial class UniqueParamStIdPrgr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Progress_StudentId",
                table: "Progress");

            migrationBuilder.CreateIndex(
                name: "IX_Progress_StudentId",
                table: "Progress",
                column: "StudentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Progress_StudentId",
                table: "Progress");

            migrationBuilder.CreateIndex(
                name: "IX_Progress_StudentId",
                table: "Progress",
                column: "StudentId");
        }
    }
}
