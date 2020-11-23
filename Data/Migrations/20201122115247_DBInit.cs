using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Data.Migrations
{
    public partial class DBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VacationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Balance = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    fullname = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    GenderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacationAllocations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<int>(nullable: false),
                    VacationTypeId = table.Column<int>(nullable: false),
                    NumberOfDays = table.Column<int>(nullable: false),
                    UsedDays = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationAllocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacationAllocations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacationAllocations_VacationTypes_VacationTypeId",
                        column: x => x.VacationTypeId,
                        principalTable: "VacationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacationRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<int>(nullable: false),
                    VacationTypeId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    DateRequested = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Cancelled = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacationRequests_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacationRequests_VacationTypes_VacationTypeId",
                        column: x => x.VacationTypeId,
                        principalTable: "VacationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "F" },
                    { 1, "M" },
                    { 3, "other" }
                });

            migrationBuilder.InsertData(
                table: "VacationTypes",
                columns: new[] { "Id", "Balance", "Name" },
                values: new object[,]
                {
                    { 1, 7, "Casual" },
                    { 2, 14, "Schedule" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Birthdate", "Email", "GenderId", "fullname" },
                values: new object[] { 3, new DateTime(1956, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "nadiamohamed97@gmail.com", 2, "Nadia Mohamed Hassan" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Birthdate", "Email", "GenderId", "fullname" },
                values: new object[] { 2, new DateTime(1998, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "hassankhalil@gmail.com", 1, "Hassan Khalil Mohamed" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Birthdate", "Email", "GenderId", "fullname" },
                values: new object[] { 1, new DateTime(1997, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "amrsaadeldin97@gmail.com", 1, "Amr Sherief Abdelhakim" });

            migrationBuilder.InsertData(
                table: "VacationRequests",
                columns: new[] { "Id", "Cancelled", "DateRequested", "EmployeeId", "EndDate", "StartDate", "Status", "VacationTypeId" },
                values: new object[] { 2, false, new DateTime(2020, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2020, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2 });

            migrationBuilder.InsertData(
                table: "VacationRequests",
                columns: new[] { "Id", "Cancelled", "DateRequested", "EmployeeId", "EndDate", "StartDate", "Status", "VacationTypeId" },
                values: new object[] { 1, false, new DateTime(2020, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_GenderId",
                table: "Employees",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationAllocations_EmployeeId",
                table: "VacationAllocations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationAllocations_VacationTypeId",
                table: "VacationAllocations",
                column: "VacationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationRequests_EmployeeId",
                table: "VacationRequests",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationRequests_VacationTypeId",
                table: "VacationRequests",
                column: "VacationTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacationAllocations");

            migrationBuilder.DropTable(
                name: "VacationRequests");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "VacationTypes");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}
