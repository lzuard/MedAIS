using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedData.Migrations
{
    /// <inheritdoc />
    public partial class deleteDiagnoses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnosis_s_Mkbs_MkbId",
                table: "Diagnosis_s");

            migrationBuilder.DropTable(
                name: "Diagnoses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mkbs",
                table: "Mkbs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diagnosis_s",
                table: "Diagnosis_s");

            migrationBuilder.RenameTable(
                name: "Mkbs",
                newName: "Mkb");

            migrationBuilder.RenameTable(
                name: "Diagnosis_s",
                newName: "Diagnosis");

            migrationBuilder.RenameIndex(
                name: "IX_Diagnosis_s_MkbId",
                table: "Diagnosis",
                newName: "IX_Diagnosis_MkbId");

            migrationBuilder.AddColumn<int>(
                name: "HospitalizationId",
                table: "Diagnosis",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mkb",
                table: "Mkb",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diagnosis",
                table: "Diagnosis",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosis_HospitalizationId",
                table: "Diagnosis",
                column: "HospitalizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnosis_Hospitalizations_HospitalizationId",
                table: "Diagnosis",
                column: "HospitalizationId",
                principalTable: "Hospitalizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnosis_Mkb_MkbId",
                table: "Diagnosis",
                column: "MkbId",
                principalTable: "Mkb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnosis_Hospitalizations_HospitalizationId",
                table: "Diagnosis");

            migrationBuilder.DropForeignKey(
                name: "FK_Diagnosis_Mkb_MkbId",
                table: "Diagnosis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mkb",
                table: "Mkb");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diagnosis",
                table: "Diagnosis");

            migrationBuilder.DropIndex(
                name: "IX_Diagnosis_HospitalizationId",
                table: "Diagnosis");

            migrationBuilder.DropColumn(
                name: "HospitalizationId",
                table: "Diagnosis");

            migrationBuilder.RenameTable(
                name: "Mkb",
                newName: "Mkbs");

            migrationBuilder.RenameTable(
                name: "Diagnosis",
                newName: "Diagnosis_s");

            migrationBuilder.RenameIndex(
                name: "IX_Diagnosis_MkbId",
                table: "Diagnosis_s",
                newName: "IX_Diagnosis_s_MkbId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mkbs",
                table: "Mkbs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diagnosis_s",
                table: "Diagnosis_s",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Diagnoses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiagnosisId = table.Column<int>(type: "integer", nullable: false),
                    HospitalizationId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnoses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagnoses_Diagnosis_s_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "Diagnosis_s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diagnoses_Hospitalizations_HospitalizationId",
                        column: x => x.HospitalizationId,
                        principalTable: "Hospitalizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_DiagnosisId",
                table: "Diagnoses",
                column: "DiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_HospitalizationId",
                table: "Diagnoses",
                column: "HospitalizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnosis_s_Mkbs_MkbId",
                table: "Diagnosis_s",
                column: "MkbId",
                principalTable: "Mkbs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
