using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedData.Migrations
{
    /// <inheritdoc />
    public partial class Fix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Checkup_s",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Checkup_s_UserId",
                table: "Checkup_s",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkup_s_Users_UserId",
                table: "Checkup_s",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkup_s_Users_UserId",
                table: "Checkup_s");

            migrationBuilder.DropIndex(
                name: "IX_Checkup_s_UserId",
                table: "Checkup_s");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Checkup_s");
        }
    }
}
