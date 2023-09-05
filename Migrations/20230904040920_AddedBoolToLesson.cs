using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyect_alfabet_7._0.Migrations
{
    /// <inheritdoc />
    public partial class AddedBoolToLesson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isLast",
                table: "Lessons",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isLast",
                table: "Lessons");
        }
    }
}
