using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedData.Migrations
{
    /// <inheritdoc />
    public partial class DeleteChecupsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Checkups");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Checkup",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "HospitalizationId",
                table: "Checkup",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Checkup_HospitalizationId",
                table: "Checkup",
                column: "HospitalizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkup_Hospitalizations_HospitalizationId",
                table: "Checkup",
                column: "HospitalizationId",
                principalTable: "Hospitalizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkup_Hospitalizations_HospitalizationId",
                table: "Checkup");

            migrationBuilder.DropIndex(
                name: "IX_Checkup_HospitalizationId",
                table: "Checkup");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Checkup");

            migrationBuilder.DropColumn(
                name: "HospitalizationId",
                table: "Checkup");

            migrationBuilder.CreateTable(
                name: "Checkups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CheckupId = table.Column<int>(type: "integer", nullable: false),
                    HospitalizationId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checkups_Checkup_CheckupId",
                        column: x => x.CheckupId,
                        principalTable: "Checkup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Checkups_Hospitalizations_HospitalizationId",
                        column: x => x.HospitalizationId,
                        principalTable: "Hospitalizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checkups_CheckupId",
                table: "Checkups",
                column: "CheckupId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkups_HospitalizationId",
                table: "Checkups",
                column: "HospitalizationId");
        }
    }
}
