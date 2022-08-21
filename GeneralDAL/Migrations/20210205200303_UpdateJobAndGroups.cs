using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class UpdateJobAndGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 26,
                column: "Name",
                value: "JobNew");

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 27,
                column: "Name",
                value: "JobEdit");

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 28,
                column: "Name",
                value: "JobDelete");

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 8,
                column: "ShowInMenu",
                value: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 26,
                column: "Name",
                value: "JobDefine");

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 27,
                column: "Name",
                value: "JobDefine");

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 28,
                column: "Name",
                value: "JobDefine");

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 8,
                column: "ShowInMenu",
                value: true);
        }
    }
}
