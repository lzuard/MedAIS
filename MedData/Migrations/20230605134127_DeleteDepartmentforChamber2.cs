using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedData.Migrations
{
    /// <inheritdoc />
    public partial class DeleteDepartmentforChamber2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chambers_Departments_DepartmentId",
                table: "Chambers");

            migrationBuilder.DropIndex(
                name: "IX_Chambers_DepartmentId",
                table: "Chambers");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Chambers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Chambers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chambers_DepartmentId",
                table: "Chambers",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chambers_Departments_DepartmentId",
                table: "Chambers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }
    }
}
