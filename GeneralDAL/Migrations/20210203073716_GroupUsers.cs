using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class GroupUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAccess",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuAction",
                columns: new[] { "Id", "MenuItemId", "Name", "Priority", "ShowInToolbar", "Title" },
                values: new object[] { 10, 3, "GroupUsers", 4, true, "انتخاب اعضای گروه" });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuAction",
                columns: new[] { "Id", "MenuItemId", "Name", "Priority", "ShowInToolbar", "Title" },
                values: new object[] { 11, 4, "GroupUsers", 1, true, "انتخاب اعضای گروه" });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuItem",
                columns: new[] { "Id", "ActionName", "CategoryId", "Code", "ControllerName", "DialogSize", "Name", "Priority", "ShowInMenu" },
                values: new object[] { 5, "GroupUsers", 1, "GroupUsers", "Security", "medium", "ایجاد و ویرایش اعضای گروه‌", 5, false });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuAccess",
                columns: new[] { "Id", "MenuItemId", "UserId" },
                values: new object[] { 5, 5, 1 });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuAction",
                columns: new[] { "Id", "MenuItemId", "Name", "Priority", "ShowInToolbar", "Title" },
                values: new object[] { 15, 5, "Add", 1, true, "اضافه کردن" });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuActionAccess",
                columns: new[] { "Id", "MenuActionId", "UserId" },
                values: new object[,]
                {
                    { 10, 10, 1 },
                    { 11, 11, 1 }
                });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuActionAccess",
                columns: new[] { "Id", "MenuActionId", "UserId" },
                values: new object[] { 15, 15, 1 });
        }
    }
}
