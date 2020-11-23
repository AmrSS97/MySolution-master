using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UpdateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfDays",
                table: "VacationAllocations");

            migrationBuilder.DropColumn(
                name: "UsedDays",
                table: "VacationAllocations");

            migrationBuilder.AddColumn<int>(
                name: "Used",
                table: "VacationAllocations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: true);

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Used",
                table: "VacationAllocations");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfDays",
                table: "VacationAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsedDays",
                table: "VacationAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: false);

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: false);
        }
    }
}
