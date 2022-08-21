using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class RentMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 25,
                column: "Code",
                value: "Rents");

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 26,
                column: "Code",
                value: "RentDefine");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 25,
                column: "Code",
                value: "Tariffs");

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 26,
                column: "Code",
                value: "TariffDefine");
        }
    }
}
