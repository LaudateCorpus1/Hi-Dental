using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseLayer.Migrations
{
    public partial class AddIsDoctorToUserType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDoctor",
                table: "UserTypes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDoctor",
                table: "UserTypes");
        }
    }
}
