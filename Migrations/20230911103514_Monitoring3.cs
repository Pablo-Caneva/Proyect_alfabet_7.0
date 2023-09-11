using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyect_alfabet_7._0.Migrations
{
    /// <inheritdoc />
    public partial class Monitoring3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentLesson",
                table: "UserLogin",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentModule",
                table: "UserLogin",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "StudentProgress",
                table: "UserLogin",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentLesson",
                table: "UserLogin");

            migrationBuilder.DropColumn(
                name: "StudentModule",
                table: "UserLogin");

            migrationBuilder.DropColumn(
                name: "StudentProgress",
                table: "UserLogin");
        }
    }
}
