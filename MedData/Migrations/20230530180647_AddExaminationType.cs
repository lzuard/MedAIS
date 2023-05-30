using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedData.Migrations
{
    /// <inheritdoc />
    public partial class AddExaminationType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Result",
                table: "Treatments",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "ExaminationTypeId",
                table: "Examinations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ExaminationType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_ExaminationTypeId",
                table: "Examinations",
                column: "ExaminationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_ExaminationType_ExaminationTypeId",
                table: "Examinations",
                column: "ExaminationTypeId",
                principalTable: "ExaminationType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_ExaminationType_ExaminationTypeId",
                table: "Examinations");

            migrationBuilder.DropTable(
                name: "ExaminationType");

            migrationBuilder.DropIndex(
                name: "IX_Examinations_ExaminationTypeId",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "ExaminationTypeId",
                table: "Examinations");

            migrationBuilder.AlterColumn<string>(
                name: "Result",
                table: "Treatments",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
