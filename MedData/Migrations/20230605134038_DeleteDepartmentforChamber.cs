using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedData.Migrations
{
    /// <inheritdoc />
    public partial class DeleteDepartmentforChamber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chambers_Departments_DepartmentId",
                table: "Chambers");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Chambers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Chambers_Departments_DepartmentId",
                table: "Chambers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chambers_Departments_DepartmentId",
                table: "Chambers");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Chambers",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Chambers_Departments_DepartmentId",
                table: "Chambers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
