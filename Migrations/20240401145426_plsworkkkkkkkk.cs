using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmApplication.Migrations
{
    /// <inheritdoc />
    public partial class plsworkkkkkkkk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskField = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskResources = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskEquipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskWorker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldValuesFieldID = table.Column<int>(type: "int", nullable: false),
                    ResourcesValuesResourceId = table.Column<int>(type: "int", nullable: false),
                    EquipmentValuesId = table.Column<int>(type: "int", nullable: false),
                    WorkersValuesWorkerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_Tasks_Equipment_EquipmentValuesId",
                        column: x => x.EquipmentValuesId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Fields_FieldValuesFieldID",
                        column: x => x.FieldValuesFieldID,
                        principalTable: "Fields",
                        principalColumn: "FieldID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Resources_ResourcesValuesResourceId",
                        column: x => x.ResourcesValuesResourceId,
                        principalTable: "Resources",
                        principalColumn: "ResourceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Workers_WorkersValuesWorkerID",
                        column: x => x.WorkersValuesWorkerID,
                        principalTable: "Workers",
                        principalColumn: "WorkerID",
                        onDelete: ReferentialAction.Cascade);
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
        }
    }
}
