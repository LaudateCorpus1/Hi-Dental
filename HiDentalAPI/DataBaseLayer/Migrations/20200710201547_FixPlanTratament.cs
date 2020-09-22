using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseLayer.Migrations
{
    public partial class FixPlanTratament : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "ServiceOfPattients");

            migrationBuilder.AddColumn<Guid>(
                name: "PlanId",
                table: "ServiceOfPattients",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    PatientId = table.Column<Guid>(nullable: false),
                    TypeOfPlan = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plan_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    PlantId = table.Column<Guid>(nullable: false),
                    PlanId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOfPattients_PlanId",
                table: "ServiceOfPattients",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PlanId",
                table: "Payment",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_PatientId",
                table: "Plan",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOfPattients_Plan_PlanId",
                table: "ServiceOfPattients",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOfPattients_Plan_PlanId",
                table: "ServiceOfPattients");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOfPattients_PlanId",
                table: "ServiceOfPattients");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "ServiceOfPattients");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "ServiceOfPattients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
