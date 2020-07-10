using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseLayer.Migrations
{
    public partial class RemovePrincipalOficceEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DentalBranch_PrincipalOffices_PrincipalOfficeId",
                table: "DentalBranch");

            migrationBuilder.DropTable(
                name: "PrincipalOffices");

            migrationBuilder.DropIndex(
                name: "IX_DentalBranch_PrincipalOfficeId",
                table: "DentalBranch");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "DentalBranch");

            migrationBuilder.AlterColumn<Guid>(
                name: "PrincipalOfficeId",
                table: "DentalBranch",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "PrincipalOfficeId",
                table: "DentalBranch",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AppointmentId",
                table: "DentalBranch",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "PrincipalOffices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalOffices", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DentalBranch_PrincipalOfficeId",
                table: "DentalBranch",
                column: "PrincipalOfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DentalBranch_PrincipalOffices_PrincipalOfficeId",
                table: "DentalBranch",
                column: "PrincipalOfficeId",
                principalTable: "PrincipalOffices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
