using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookLoversProject.Infrastructure.Migrations
{
    public partial class AddIdentityIdToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdentityId",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "Admins");
        }
    }
}
