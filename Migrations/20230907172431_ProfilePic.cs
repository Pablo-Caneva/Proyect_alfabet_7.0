using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyect_alfabet_7._0.Migrations
{
    /// <inheritdoc />
    public partial class ProfilePic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "UserLogin");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePictureBytes",
                table: "UserLogin",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePictureBytes",
                table: "UserLogin");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "UserLogin",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
