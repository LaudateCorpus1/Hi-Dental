using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseLayer.Migrations
{
    public partial class addServiceOfPattientwithdentalbranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DentalBranchId",
                table: "ServiceOfPattients",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOfPattients_DentalBranchId",
                table: "ServiceOfPattients",
                column: "DentalBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOfPattients_DentalBranch_DentalBranchId",
                table: "ServiceOfPattients",
                column: "DentalBranchId",
                principalTable: "DentalBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOfPattients_DentalBranch_DentalBranchId",
                table: "ServiceOfPattients");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOfPattients_DentalBranchId",
                table: "ServiceOfPattients");

            migrationBuilder.DropColumn(
                name: "DentalBranchId",
                table: "ServiceOfPattients");
        }
    }
}
