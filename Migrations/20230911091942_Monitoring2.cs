using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyect_alfabet_7._0.Migrations
{
    /// <inheritdoc />
    public partial class Monitoring2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLogin_UserLogin_TutorId",
                table: "UserLogin");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogin_UserLogin_TutorId",
                table: "UserLogin",
                column: "TutorId",
                principalTable: "UserLogin",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLogin_UserLogin_TutorId",
                table: "UserLogin");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogin_UserLogin_TutorId",
                table: "UserLogin",
                column: "TutorId",
                principalTable: "UserLogin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
