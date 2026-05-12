using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintenanceSystem.Migrations
{
    /// <inheritdoc />
    public partial class MakeEquipmentOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Equipments_EquipmentId",
                table: "Incidents");

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentId",
                table: "Incidents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Equipments_EquipmentId",
                table: "Incidents",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Equipments_EquipmentId",
                table: "Incidents");

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentId",
                table: "Incidents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Equipments_EquipmentId",
                table: "Incidents",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
