using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseLayer.Migrations
{
    public partial class FixAddingAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_DentalBranch_DentalBranchId",
                table: "Appointments");

            migrationBuilder.AlterColumn<Guid>(
                name: "DentalBranchId",
                table: "Appointments",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_DentalBranch_DentalBranchId",
                table: "Appointments",
                column: "DentalBranchId",
                principalTable: "DentalBranch",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_DentalBranch_DentalBranchId",
                table: "Appointments");

            migrationBuilder.AlterColumn<Guid>(
                name: "DentalBranchId",
                table: "Appointments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_DentalBranch_DentalBranchId",
                table: "Appointments",
                column: "DentalBranchId",
                principalTable: "DentalBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
