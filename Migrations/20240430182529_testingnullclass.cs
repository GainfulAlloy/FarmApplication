using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmApplication.Migrations
{
    /// <inheritdoc />
    public partial class testingnullclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Equipment_EquipmentValuesId",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentValuesId",
                table: "Tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Equipment_EquipmentValuesId",
                table: "Tasks",
                column: "EquipmentValuesId",
                principalTable: "Equipment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Equipment_EquipmentValuesId",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentValuesId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Equipment_EquipmentValuesId",
                table: "Tasks",
                column: "EquipmentValuesId",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
