using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class DiscountPriority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 25,
                column: "Priority",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 26,
                column: "Priority",
                value: 6);

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 30,
                column: "Priority",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 31,
                column: "Priority",
                value: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 25,
                column: "Priority",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 26,
                column: "Priority",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 30,
                column: "Priority",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 31,
                column: "Priority",
                value: 6);
        }
    }
}
