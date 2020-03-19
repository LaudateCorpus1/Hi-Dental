using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseLayer.Migrations
{
    public partial class InitPatientv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Patients",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "DentalBranchId",
                table: "Patients",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DentalBranchId",
                table: "Patients",
                column: "DentalBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_DentalBranch_DentalBranchId",
                table: "Patients",
                column: "DentalBranchId",
                principalTable: "DentalBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_DentalBranch_DentalBranchId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_DentalBranchId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DentalBranchId",
                table: "Patients");
        }
    }
}
