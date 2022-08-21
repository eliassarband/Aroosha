using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class UpdateRegionData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Gnr",
                table: "Region",
                keyColumn: "Id",
                keyValue: 1,
                column: "Code",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Gnr",
                table: "Region",
                keyColumn: "Id",
                keyValue: 2,
                column: "Code",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Gnr",
                table: "Region",
                keyColumn: "Id",
                keyValue: 3,
                column: "Code",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Gnr",
                table: "Region",
                keyColumn: "Id",
                keyValue: 1,
                column: "Code",
                value: 98);

            migrationBuilder.UpdateData(
                schema: "Gnr",
                table: "Region",
                keyColumn: "Id",
                keyValue: 2,
                column: "Code",
                value: 31);

            migrationBuilder.UpdateData(
                schema: "Gnr",
                table: "Region",
                keyColumn: "Id",
                keyValue: 3,
                column: "Code",
                value: 313);
        }
    }
}
