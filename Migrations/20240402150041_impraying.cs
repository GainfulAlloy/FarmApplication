using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmApplication.Migrations
{
    /// <inheritdoc />
    public partial class impraying : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FarmApplicationDBUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmApplicationDBUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipmentCount = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_FarmApplicationDBUser_UserID",
                        column: x => x.UserID,
                        principalTable: "FarmApplicationDBUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    FieldID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldSize = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.FieldID);
                    table.ForeignKey(
                        name: "FK_Fields_FarmApplicationDBUser_UserID",
                        column: x => x.UserID,
                        principalTable: "FarmApplicationDBUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    ResourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResourceCount = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.ResourceId);
                    table.ForeignKey(
                        name: "FK_Resources_FarmApplicationDBUser_UserID",
                        column: x => x.UserID,
                        principalTable: "FarmApplicationDBUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.WorkerID);
                    table.ForeignKey(
                        name: "FK_Workers_FarmApplicationDBUser_UserID",
                        column: x => x.UserID,
                        principalTable: "FarmApplicationDBUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskField = table.Column<int>(type: "int", nullable: false),
                    TaskResources = table.Column<int>(type: "int", nullable: false),
                    TaskEquipment = table.Column<int>(type: "int", nullable: false),
                    TaskWorker = table.Column<int>(type: "int", nullable: false),
                    FieldValuesFieldID = table.Column<int>(type: "int", nullable: false),
                    ResourcesValuesResourceId = table.Column<int>(type: "int", nullable: false),
                    EquipmentValuesId = table.Column<int>(type: "int", nullable: false),
                    WorkersValuesWorkerID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_Tasks_Equipment_EquipmentValuesId",
                        column: x => x.EquipmentValuesId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_FarmApplicationDBUser_UserID",
                        column: x => x.UserID,
                        principalTable: "FarmApplicationDBUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Fields_FieldValuesFieldID",
                        column: x => x.FieldValuesFieldID,
                        principalTable: "Fields",
                        principalColumn: "FieldID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Resources_ResourcesValuesResourceId",
                        column: x => x.ResourcesValuesResourceId,
                        principalTable: "Resources",
                        principalColumn: "ResourceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Workers_WorkersValuesWorkerID",
                        column: x => x.WorkersValuesWorkerID,
                        principalTable: "Workers",
                        principalColumn: "WorkerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MapsField",
                columns: Table => new
                {
                    FarmID = Table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    ManagerName = Table.Column<int>(type: "int", nullable: false),
                    Latitude1 = Table.Column<float>(type: "float", nullable: false),
                    Longitude1 = Table.Column<float>(type: "float", nullable: false),
                    Latitude2 = Table.Column<float>(type: "float", nullable: false),
                    Longitude2 = Table.Column<float>(type: "float", nullable: false),
                    Latitude3 = Table.Column<float>(type: "float", nullable: false),
                    Longitude3 = Table.Column<float>(type: "float", nullable: false),
                    Latitude4 = Table.Column<float>(type: "float", nullable: false),
                    Longitude4 = Table.Column<float>(type: "float", nullable: false),
                    FieldID = Table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.FarmID);
                    table.ForeignKey(
                        name: "FK_Fields_FieldID",
                        column: x => x.FieldID,
                        principalTable: "Fields",
                        principalColumn: "FieldID",
                        onDelete: ReferentialAction.Restrict);

                }

                );

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_UserID",
                table: "Equipment",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_UserID",
                table: "Fields",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_UserID",
                table: "Resources",
                column: "UserID");

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
                name: "IX_Tasks_UserID",
                table: "Tasks",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_WorkersValuesWorkerID",
                table: "Tasks",
                column: "WorkersValuesWorkerID");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_UserID",
                table: "Workers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_MapsField_MapID",
                table: "MapsField",
                column: "FarmID");
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

            migrationBuilder.DropTable(
                name: "FarmApplicationDBUser");

            migrationBuilder.DropTable(
                name: "MapsField");
        }
    }
}
