using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedData.Migrations
{
    /// <inheritdoc />
    public partial class DeletePatientInChamber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientInChambers");

            migrationBuilder.AddColumn<int>(
                name: "ChamberId",
                table: "Hospitalizations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalizations_ChamberId",
                table: "Hospitalizations",
                column: "ChamberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitalizations_Chambers_ChamberId",
                table: "Hospitalizations",
                column: "ChamberId",
                principalTable: "Chambers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hospitalizations_Chambers_ChamberId",
                table: "Hospitalizations");

            migrationBuilder.DropIndex(
                name: "IX_Hospitalizations_ChamberId",
                table: "Hospitalizations");

            migrationBuilder.DropColumn(
                name: "ChamberId",
                table: "Hospitalizations");

            migrationBuilder.CreateTable(
                name: "PatientInChambers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChamberId = table.Column<int>(type: "integer", nullable: false),
                    HospitalizationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientInChambers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientInChambers_Chambers_ChamberId",
                        column: x => x.ChamberId,
                        principalTable: "Chambers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientInChambers_Hospitalizations_HospitalizationId",
                        column: x => x.HospitalizationId,
                        principalTable: "Hospitalizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientInChambers_ChamberId",
                table: "PatientInChambers",
                column: "ChamberId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientInChambers_HospitalizationId",
                table: "PatientInChambers",
                column: "HospitalizationId");
        }
    }
}
