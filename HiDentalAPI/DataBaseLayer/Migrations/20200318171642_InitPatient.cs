using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseLayer.Migrations
{
    public partial class InitPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_Patients_PatientId",
                table: "Consultations");

            migrationBuilder.DropIndex(
                name: "IX_Consultations_PatientId",
                table: "Consultations");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Address_Office",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Cellphone_number",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Identification_card",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PhoneNumber_Office",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Referred_to_by",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Patients");

            migrationBuilder.AddColumn<string>(
                name: "AddressOffice",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Patients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IdentificationCard",
                table: "Patients",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "MedicalAlert",
                table: "Patients",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Patients",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReferredBy",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkPhoneNumber",
                table: "Patients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressOffice",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "IdentificationCard",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MedicalAlert",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ReferredBy",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "WorkPhoneNumber",
                table: "Patients");

            migrationBuilder.AddColumn<string>(
                name: "Address_Office",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cellphone_number",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Identification_card",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber_Office",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Referred_to_by",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_PatientId",
                table: "Consultations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_Patients_PatientId",
                table: "Consultations",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
