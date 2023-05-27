using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedData.Migrations
{
    /// <inheritdoc />
    public partial class Fix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkups_Checkup_s_СheckupId",
                table: "Checkups");

            migrationBuilder.DropForeignKey(
                name: "FK_Checkups_Checkups_Checkup_sId",
                table: "Checkups");

            migrationBuilder.DropIndex(
                name: "IX_Checkups_СheckupId",
                table: "Checkups");

            migrationBuilder.DropIndex(
                name: "IX_AnamnesisVitae_HospitalizationId",
                table: "AnamnesisVitae");

            migrationBuilder.DropColumn(
                name: "СheckupId",
                table: "Checkups");

            migrationBuilder.CreateIndex(
                name: "IX_AnamnesisVitae_HospitalizationId",
                table: "AnamnesisVitae",
                column: "HospitalizationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkups_Checkup_s_Checkup_sId",
                table: "Checkups",
                column: "Checkup_sId",
                principalTable: "Checkup_s",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkups_Checkup_s_Checkup_sId",
                table: "Checkups");

            migrationBuilder.DropIndex(
                name: "IX_AnamnesisVitae_HospitalizationId",
                table: "AnamnesisVitae");

            migrationBuilder.AddColumn<int>(
                name: "СheckupId",
                table: "Checkups",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Checkups_СheckupId",
                table: "Checkups",
                column: "СheckupId");

            migrationBuilder.CreateIndex(
                name: "IX_AnamnesisVitae_HospitalizationId",
                table: "AnamnesisVitae",
                column: "HospitalizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkups_Checkup_s_СheckupId",
                table: "Checkups",
                column: "СheckupId",
                principalTable: "Checkup_s",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkups_Checkups_Checkup_sId",
                table: "Checkups",
                column: "Checkup_sId",
                principalTable: "Checkups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
