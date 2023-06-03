using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedData.Migrations
{
    /// <inheritdoc />
    public partial class addDiagnosisIsMain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "Diagnosis_s",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "Diagnosis_s");
        }
    }
}
