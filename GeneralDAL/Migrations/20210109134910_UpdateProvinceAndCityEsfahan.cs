using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class UpdateProvinceAndCityEsfahan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Gnr",
                table: "Region",
                keyColumn: "Id",
                keyValue: 2,
                column: "Code",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "Gnr",
                table: "Region",
                keyColumn: "Id",
                keyValue: 3,
                column: "Code",
                value: 6);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
