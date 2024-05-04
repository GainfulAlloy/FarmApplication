using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmApplication.Migrations
{
    /// <inheritdoc />
    public partial class hope : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipmentCount = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    FieldID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldSize = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.FieldID);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    ResourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResourceCount = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.ResourceId);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    WorkerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkerSalary = table.Column<int>(type: "int", nullable: false),
                    EmployedUntil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.WorkerID);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskField = table.Column<int>(type: "int", nullable: true),
                    TaskResources = table.Column<int>(type: "int", nullable: true),
                    TaskResourceCount = table.Column<int>(type: "int", nullable: true),
                    TaskEquipment = table.Column<int>(type: "int", nullable: true),
                    TaskEquipmentCount = table.Column<int>(type: "int", nullable: true),
                    TaskWorker = table.Column<int>(type: "int", nullable: true),
                    TaskStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FieldValuesFieldID = table.Column<int>(type: "int", nullable: true),
                    ResourcesValuesResourceId = table.Column<int>(type: "int", nullable: true),
                    EquipmentValuesId = table.Column<int>(type: "int", nullable: true),
                    WorkersValuesWorkerID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_Tasks_Equipment_EquipmentValuesId",
                        column: x => x.EquipmentValuesId,
                        principalTable: "Equipment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Fields_FieldValuesFieldID",
                        column: x => x.FieldValuesFieldID,
                        principalTable: "Fields",
                        principalColumn: "FieldID");
                    table.ForeignKey(
                        name: "FK_Tasks_Resources_ResourcesValuesResourceId",
                        column: x => x.ResourcesValuesResourceId,
                        principalTable: "Resources",
                        principalColumn: "ResourceId");
                    table.ForeignKey(
                        name: "FK_Tasks_Workers_WorkersValuesWorkerID",
                        column: x => x.WorkersValuesWorkerID,
                        principalTable: "Workers",
                        principalColumn: "WorkerID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_EquipmentValuesId",
                table: "Tasks",
                column: "EquipmentValuesId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_FieldValuesFieldID",
                table: "Tasks",
                column: "FieldValuesFieldID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ResourcesValuesResourceId",
                table: "Tasks",
                column: "ResourcesValuesResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_WorkersValuesWorkerID",
                table: "Tasks",
                column: "WorkersValuesWorkerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Workers");
        }
    }
}
