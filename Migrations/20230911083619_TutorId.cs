using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyect_alfabet_7._0.Migrations
{
    /// <inheritdoc />
    public partial class TutorId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLogin_UserLogin_TutorId",
                table: "UserLogin");

            migrationBuilder.DropIndex(
                name: "IX_UserLogin_TutorId",
                table: "UserLogin");

            migrationBuilder.DropColumn(
                name: "TutorId",
                table: "UserLogin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TutorId",
                table: "UserLogin",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_TutorId",
                table: "UserLogin",
                column: "TutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogin_UserLogin_TutorId",
                table: "UserLogin",
                column: "TutorId",
                principalTable: "UserLogin",
                principalColumn: "Id");
        }
    }
}
