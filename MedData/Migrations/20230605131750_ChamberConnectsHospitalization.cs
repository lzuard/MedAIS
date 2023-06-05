using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedData.Migrations
{
    /// <inheritdoc />
    public partial class ChamberConnectsHospitalization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientInChambers_MedCards_MedCardId",
                table: "PatientInChambers");

            migrationBuilder.RenameColumn(
                name: "MedCardId",
                table: "PatientInChambers",
                newName: "HospitalizationId");

            migrationBuilder.RenameIndex(
                name: "IX_PatientInChambers_MedCardId",
                table: "PatientInChambers",
                newName: "IX_PatientInChambers_HospitalizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientInChambers_Hospitalizations_HospitalizationId",
                table: "PatientInChambers",
                column: "HospitalizationId",
                principalTable: "Hospitalizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientInChambers_Hospitalizations_HospitalizationId",
                table: "PatientInChambers");

            migrationBuilder.RenameColumn(
                name: "HospitalizationId",
                table: "PatientInChambers",
                newName: "MedCardId");

            migrationBuilder.RenameIndex(
                name: "IX_PatientInChambers_HospitalizationId",
                table: "PatientInChambers",
                newName: "IX_PatientInChambers_MedCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientInChambers_MedCards_MedCardId",
                table: "PatientInChambers",
                column: "MedCardId",
                principalTable: "MedCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
