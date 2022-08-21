using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class RentAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuAction",
                columns: new[] { "Id", "MenuItemId", "Name", "Priority", "ShowInToolbar", "Title" },
                values: new object[] { 87, 25, "NewRents", 4, true, "ثبت اجاره دسته ای" });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuItem",
                columns: new[] { "Id", "ActionName", "CategoryId", "Code", "ControllerName", "DialogSize", "Name", "Priority", "ShowInMenu" },
                values: new object[] { 27, "RentsDefine", 4, "RentsDefine", "Market", "medium", "ثبت اجاره دسته ای غرفه", 5, true });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuAction",
                columns: new[] { "Id", "MenuItemId", "Name", "Priority", "ShowInToolbar", "Title" },
                values: new object[] { 88, 27, "Save", 1, true, "ذخیره" });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuAction",
                columns: new[] { "Id", "MenuItemId", "Name", "Priority", "ShowInToolbar", "Title" },
                values: new object[] { 89, 27, "SaveAndNew", 2, true, "ذخیره و جدید" });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuAction",
                columns: new[] { "Id", "MenuItemId", "Name", "Priority", "ShowInToolbar", "Title" },
                values: new object[] { 90, 27, "SaveAndContinue", 3, true, "ذخیره و ادامه" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 27);
        }
    }
}
