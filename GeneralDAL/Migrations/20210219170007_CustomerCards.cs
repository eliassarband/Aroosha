using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class CustomerCards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "Name", "Title" },
                values: new object[] { "CustomerCards", "کارت عضویت" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "Name", "Title" },
                values: new object[] { "New", "تعریف کارت" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "Name", "Title" },
                values: new object[] { "Edit", "ویرایش کارت" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Name", "Title" },
                values: new object[] { "Delete", "حذف کارت" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ActionName", "Code", "Name" },
                values: new object[] { "CustomerCards", "CustomerCards", "کارت عضویت" });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuItem",
                columns: new[] { "Id", "ActionName", "CategoryId", "Code", "ControllerName", "DialogSize", "Name", "Priority", "ShowInMenu" },
                values: new object[] { 22, "CustomerCardDefine", 5, "CustomerCardDefine", "Market", "medium", "تعریف کارت عضویت", 4, false });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuAccess",
                columns: new[] { "Id", "GroupId", "MenuItemId", "UserId" },
                values: new object[] { 22, null, 22, 1 });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuAction",
                columns: new[] { "Id", "MenuItemId", "Name", "Priority", "ShowInToolbar", "Title" },
                values: new object[,]
                {
                    { 69, 22, "Save", 1, true, "ذخیره" },
                    { 70, 22, "SaveAndNew", 2, true, "ذخیره و جدید" },
                    { 71, 22, "SaveAndContinue", 3, true, "ذخیره و ادامه" }
                });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuActionAccess",
                columns: new[] { "Id", "GroupId", "MenuActionId", "UserId" },
                values: new object[] { 69, null, 69, 1 });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuActionAccess",
                columns: new[] { "Id", "GroupId", "MenuActionId", "UserId" },
                values: new object[] { 70, null, 70, 1 });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuActionAccess",
                columns: new[] { "Id", "GroupId", "MenuActionId", "UserId" },
                values: new object[] { 71, null, 71, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAccess",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "Name", "Title" },
                values: new object[] { "CardDefine", "تعریف کارت عضویت" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "Name", "Title" },
                values: new object[] { "Save", "ذخیره" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "Name", "Title" },
                values: new object[] { "SaveAndNew", "ذخیره و جدید" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Name", "Title" },
                values: new object[] { "SaveAndContinue", "ذخیره و ادامه" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ActionName", "Code", "Name" },
                values: new object[] { "CustomerCardDefine", "CustomerCardDefine", "تعریف کارت عضویت" });
        }
    }
}
