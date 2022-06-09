using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test2.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    IdCar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductionYear = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.IdCar);
                });

            migrationBuilder.CreateTable(
                name: "Mechanic",
                columns: table => new
                {
                    IdMechanic = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mechanic", x => x.IdMechanic);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypeDict",
                columns: table => new
                {
                    IdServiceType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(38,17)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypeDict", x => x.IdServiceType);
                });

            migrationBuilder.CreateTable(
                name: "Inspection",
                columns: table => new
                {
                    IdInspection = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCar = table.Column<int>(type: "int", nullable: false),
                    IdMechanic = table.Column<int>(type: "int", nullable: false),
                    InspectionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspection", x => x.IdInspection);
                    table.ForeignKey(
                        name: "FK_Inspection_Car_IdCar",
                        column: x => x.IdCar,
                        principalTable: "Car",
                        principalColumn: "IdCar",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inspection_Mechanic_IdMechanic",
                        column: x => x.IdMechanic,
                        principalTable: "Mechanic",
                        principalColumn: "IdMechanic",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypeDict_Inspection",
                columns: table => new
                {
                    IdServiceType = table.Column<int>(type: "int", nullable: false),
                    IdInspection = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypeDict_Inspection", x => new { x.IdServiceType, x.IdInspection });
                    table.ForeignKey(
                        name: "FK_ServiceTypeDict_Inspection_Inspection_IdInspection",
                        column: x => x.IdInspection,
                        principalTable: "Inspection",
                        principalColumn: "IdInspection",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceTypeDict_Inspection_ServiceTypeDict_IdServiceType",
                        column: x => x.IdServiceType,
                        principalTable: "ServiceTypeDict",
                        principalColumn: "IdServiceType",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "IdCar", "Name", "ProductionYear" },
                values: new object[,]
                {
                    { 1, "A", 2000 },
                    { 2, "B", 2001 },
                    { 3, "C", 2002 }
                });

            migrationBuilder.InsertData(
                table: "Mechanic",
                columns: new[] { "IdMechanic", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "M1", "1M" },
                    { 2, "M2", "2M" },
                    { 3, "M3", "3M" }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypeDict",
                columns: new[] { "IdServiceType", "Price", "ServiceType" },
                values: new object[,]
                {
                    { 1, 100m, "A" },
                    { 2, 200m, "B" },
                    { 3, 300m, "C" }
                });

            migrationBuilder.InsertData(
                table: "Inspection",
                columns: new[] { "IdInspection", "Comment", "IdCar", "IdMechanic", "InspectionDate" },
                values: new object[,]
                {
                    { 1, "123", 1, 1, new DateTime(2022, 6, 9, 9, 26, 58, 219, DateTimeKind.Local).AddTicks(58) },
                    { 2, "123", 1, 2, new DateTime(2022, 6, 10, 9, 26, 58, 219, DateTimeKind.Local).AddTicks(92) },
                    { 3, "123", 2, 2, new DateTime(2022, 6, 11, 9, 26, 58, 219, DateTimeKind.Local).AddTicks(96) },
                    { 4, "123", 3, 3, new DateTime(2022, 6, 12, 9, 26, 58, 219, DateTimeKind.Local).AddTicks(99) }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypeDict_Inspection",
                columns: new[] { "IdInspection", "IdServiceType", "Comments" },
                values: new object[,]
                {
                    { 1, 1, "123" },
                    { 2, 1, "123" },
                    { 3, 2, "123" },
                    { 4, 3, "123" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inspection_IdCar",
                table: "Inspection",
                column: "IdCar");

            migrationBuilder.CreateIndex(
                name: "IX_Inspection_IdMechanic",
                table: "Inspection",
                column: "IdMechanic");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypeDict_Inspection_IdInspection",
                table: "ServiceTypeDict_Inspection",
                column: "IdInspection");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceTypeDict_Inspection");

            migrationBuilder.DropTable(
                name: "Inspection");

            migrationBuilder.DropTable(
                name: "ServiceTypeDict");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Mechanic");
        }
    }
}
