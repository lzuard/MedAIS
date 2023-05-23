using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedData.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnamnesisVitae_Hospitalizations_HospitalizationID",
                table: "AnamnesisVitae");

            migrationBuilder.DropForeignKey(
                name: "FK_Checkups_Checkups_Checkup_sHospitalizationId_Checkup_sCheck~",
                table: "Checkups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientInChambers",
                table: "PatientInChambers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diagnoses",
                table: "Diagnoses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Checkups",
                table: "Checkups");

            migrationBuilder.DropIndex(
                name: "IX_Checkups_Checkup_sHospitalizationId_Checkup_sCheckUpId",
                table: "Checkups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Allergies",
                table: "Allergies");

            migrationBuilder.RenameColumn(
                name: "Checkup_sHospitalizationId",
                table: "Checkups",
                newName: "Checkup_sId");

            migrationBuilder.RenameColumn(
                name: "Checkup_sCheckUpId",
                table: "Checkups",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "HospitalizationID",
                table: "AnamnesisVitae",
                newName: "HospitalizationId");

            migrationBuilder.RenameIndex(
                name: "IX_AnamnesisVitae_HospitalizationID",
                table: "AnamnesisVitae",
                newName: "IX_AnamnesisVitae_HospitalizationId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PatientInChambers",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Diagnoses",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Checkups",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Allergies",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientInChambers",
                table: "PatientInChambers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diagnoses",
                table: "Diagnoses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Checkups",
                table: "Checkups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Allergies",
                table: "Allergies",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PatientInChambers_MedCardId",
                table: "PatientInChambers",
                column: "MedCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_HospitalizationId",
                table: "Diagnoses",
                column: "HospitalizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkups_Checkup_sId",
                table: "Checkups",
                column: "Checkup_sId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkups_HospitalizationId",
                table: "Checkups",
                column: "HospitalizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_MedCardId",
                table: "Allergies",
                column: "MedCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnamnesisVitae_Hospitalizations_HospitalizationId",
                table: "AnamnesisVitae",
                column: "HospitalizationId",
                principalTable: "Hospitalizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkups_Checkups_Checkup_sId",
                table: "Checkups",
                column: "Checkup_sId",
                principalTable: "Checkups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnamnesisVitae_Hospitalizations_HospitalizationId",
                table: "AnamnesisVitae");

            migrationBuilder.DropForeignKey(
                name: "FK_Checkups_Checkups_Checkup_sId",
                table: "Checkups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientInChambers",
                table: "PatientInChambers");

            migrationBuilder.DropIndex(
                name: "IX_PatientInChambers_MedCardId",
                table: "PatientInChambers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diagnoses",
                table: "Diagnoses");

            migrationBuilder.DropIndex(
                name: "IX_Diagnoses_HospitalizationId",
                table: "Diagnoses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Checkups",
                table: "Checkups");

            migrationBuilder.DropIndex(
                name: "IX_Checkups_Checkup_sId",
                table: "Checkups");

            migrationBuilder.DropIndex(
                name: "IX_Checkups_HospitalizationId",
                table: "Checkups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Allergies",
                table: "Allergies");

            migrationBuilder.DropIndex(
                name: "IX_Allergies_MedCardId",
                table: "Allergies");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PatientInChambers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Diagnoses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Allergies");

            migrationBuilder.RenameColumn(
                name: "Checkup_sId",
                table: "Checkups",
                newName: "Checkup_sHospitalizationId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Checkups",
                newName: "Checkup_sCheckUpId");

            migrationBuilder.RenameColumn(
                name: "HospitalizationId",
                table: "AnamnesisVitae",
                newName: "HospitalizationID");

            migrationBuilder.RenameIndex(
                name: "IX_AnamnesisVitae_HospitalizationId",
                table: "AnamnesisVitae",
                newName: "IX_AnamnesisVitae_HospitalizationID");

            migrationBuilder.AlterColumn<int>(
                name: "Checkup_sCheckUpId",
                table: "Checkups",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientInChambers",
                table: "PatientInChambers",
                columns: new[] { "MedCardId", "ChamberId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diagnoses",
                table: "Diagnoses",
                columns: new[] { "HospitalizationId", "DiagnosisId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Checkups",
                table: "Checkups",
                columns: new[] { "HospitalizationId", "CheckUpId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Allergies",
                table: "Allergies",
                columns: new[] { "MedCardId", "AllergenId" });

            migrationBuilder.CreateIndex(
                name: "IX_Checkups_Checkup_sHospitalizationId_Checkup_sCheckUpId",
                table: "Checkups",
                columns: new[] { "Checkup_sHospitalizationId", "Checkup_sCheckUpId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AnamnesisVitae_Hospitalizations_HospitalizationID",
                table: "AnamnesisVitae",
                column: "HospitalizationID",
                principalTable: "Hospitalizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkups_Checkups_Checkup_sHospitalizationId_Checkup_sCheck~",
                table: "Checkups",
                columns: new[] { "Checkup_sHospitalizationId", "Checkup_sCheckUpId" },
                principalTable: "Checkups",
                principalColumns: new[] { "HospitalizationId", "CheckUpId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
