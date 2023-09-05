using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyect_alfabet_7._0.Migrations
{
    /// <inheritdoc />
    public partial class ChangesToContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserLogin",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Content",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isLast",
                table: "Content",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserName",
                table: "UserLogin",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserLogin_UserName",
                table: "UserLogin");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "isLast",
                table: "Content");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserLogin",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
