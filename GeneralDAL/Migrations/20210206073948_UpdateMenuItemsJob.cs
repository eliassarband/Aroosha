using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class UpdateMenuItemsJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 22,
                column: "Name",
                value: "Jobs");

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Name", "Title" },
                values: new object[] { "Jobs", "تعریف مشاغل گروه" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "MenuItemId", "Name", "Priority", "Title" },
                values: new object[] { 9, "New", 1, "تعریف شغل جدید" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "MenuItemId", "Name", "Priority", "Title" },
                values: new object[] { 9, "Edit", 2, "ویرایش شغل" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Name", "Priority", "Title" },
                values: new object[] { "Delete", 3, "حذف شغل" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "MenuItemId", "Name", "Priority", "Title" },
                values: new object[] { 10, "Save", 1, "ذخیره" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "MenuItemId", "Name", "Priority", "Title" },
                values: new object[] { 10, "SaveAndNew", 2, "ذخیره و جدید" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Name", "Priority", "Title" },
                values: new object[] { "SaveAndContinue", 3, "ذخیره و ادامه" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "MenuItemId", "Name", "Priority", "Title" },
                values: new object[] { 11, "New", 1, "تعریف گروه غرفات" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "MenuItemId", "Name", "Priority", "Title" },
                values: new object[] { 11, "Edit", 2, "ویرایش گروه غرفات" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "MenuItemId", "Name", "Priority", "Title" },
                values: new object[] { 11, "Delete", 3, "حذف گروه غرفات" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Name", "Priority", "Title" },
                values: new object[] { "Shops", 4, "غرفه های گروه" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "MenuItemId", "Name", "Priority", "Title" },
                values: new object[] { 12, "Save", 1, "ذخیره" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "MenuItemId", "Name", "Priority", "Title" },
                values: new object[] { 12, "SaveAndNew", 2, "ذخیره و جدید" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "MenuItemId", "Name", "Priority", "Title" },
                values: new object[] { 12, "SaveAndContinue", 3, "ذخیره و ادامه" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Name", "Priority", "Title" },
                values: new object[] { "Shops", 4, "غرفه های گروه" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "MenuItemId", "Name", "Priority", "Title" },
                values: new object[] { 13, "New", 1, "تعریف غرفه" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "MenuItemId", "Name", "Priority", "Title" },
                values: new object[] { 13, "Edit", 2, "ویرایش غرفه" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Name", "Priority", "Title" },
                values: new object[] { "Delete", 3, "حذف غرفه" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "مدیریت گروه مشاغل");

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ActionName", "Code", "Name", "ShowInMenu" },
                values: new object[] { "Jobs", "Jobs", "مدیریت مشاغل", true });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ActionName", "CategoryId", "Code", "ControllerName", "Name", "Priority", "ShowInMenu" },
                values: new object[] { "JobDefine", 2, "JobDefine", "General", "تعریف مشاعل", 6, false });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ActionName", "Code", "Name", "Priority", "ShowInMenu" },
                values: new object[] { "ShopGroups", "ShopGroups", "گروه غرفات", 1, true });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ActionName", "Code", "Name", "Priority", "ShowInMenu" },
                values: new object[] { "ShopGroupDefine", "ShopGroupDefine", "تعریف گروه غرفات", 2, false });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ActionName", "Code", "Name", "Priority", "ShowInMenu" },
                values: new object[] { "Shops", "Shops", "غرفات", 3, true });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuItem",
                columns: new[] { "Id", "ActionName", "CategoryId", "Code", "ControllerName", "DialogSize", "Name", "Priority", "ShowInMenu" },
                values: new object[] { 14, "ShopDefine", 3, "ShopDefine", "Market", "medium", "تعریف غرفه", 4, false });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuAccess",
                columns: new[] { "Id", "GroupId", "MenuItemId", "UserId" },
                values: new object[] { 14, null, 14, 1 });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "MenuItemId", "Name", "Priority", "Title" },
                values: new object[] { 14, "Save", 1, "ذخیره" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "MenuItemId", "Name", "Priority", "Title" },
                values: new object[] { 14, "SaveAndNew", 2, "ذخیره و جدید" });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuAction",
                columns: new[] { "Id", "MenuItemId", "Name", "Priority", "ShowInToolbar", "Title" },
                values: new object[] { 46, 14, "SaveAndContinue", 3, true, "ذخیره و ادامه" });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuActionAccess",
                columns: new[] { "Id", "GroupId", "MenuActionId", "UserId" },
                values: new object[] { 46, null, 46, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAccess",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 22,
                column: "Name",
                value: "JobDefine");

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Name", "Title" },
                values: new object[] { "JobNew", "تعریف شغل" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "MenuItemId", "Name", "Priority", "Title" },
                values: new object[] { 8, "JobEdit", 5, "ویرایش شغل" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "MenuItemId", "Name", "Priority", "Title" },
                values: new object[] { 8, "JobDelete", 6, "حذف شغل" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Name", "Priority", "Title" },
                values: new object[] { "Save", 1, "ذخیره" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "MenuItemId", "Name", "Priority", "Title" },
                values: new object[] { 9, "SaveAndNew", 2, "ذخیره و جدید" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "MenuItemId", "Name", "Priority", "Title" },
                values: new object[] { 9, "SaveAndContinue", 3, "ذخیره و ادامه" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Name", "Priority", "Title" },
                values: new object[] { "New", 1, "تعریف گروه غرفات" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "MenuItemId", "Name", "Priority", "Title" },
                values: new object[] { 10, "Edit", 2, "ویرایش گروه غرفات" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "MenuItemId", "Name", "Priority", "Title" },
                values: new object[] { 10, "Delete", 3, "حذف گروه غرفات" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "MenuItemId", "Name", "Priority", "Title" },
                values: new object[] { 10, "Shops", 4, "غرفه های گروه" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Name", "Priority", "Title" },
                values: new object[] { "Save", 1, "ذخیره" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "MenuItemId", "Name", "Priority", "Title" },
                values: new object[] { 11, "SaveAndNew", 2, "ذخیره و جدید" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "MenuItemId", "Name", "Priority", "Title" },
                values: new object[] { 11, "SaveAndContinue", 3, "ذخیره و ادامه" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "MenuItemId", "Name", "Priority", "Title" },
                values: new object[] { 11, "Shops", 4, "غرفه های گروه" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Name", "Priority", "Title" },
                values: new object[] { "New", 1, "تعریف غرفه" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "MenuItemId", "Name", "Priority", "Title" },
                values: new object[] { 12, "Edit", 2, "ویرایش غرفه" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "MenuItemId", "Name", "Priority", "Title" },
                values: new object[] { 12, "Delete", 3, "حذف غرفه" });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Name", "Priority", "Title" },
                values: new object[] { "Save", 1, "ذخیره" });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuAction",
                columns: new[] { "Id", "MenuItemId", "Name", "Priority", "ShowInToolbar", "Title" },
                values: new object[,]
                {
                    { 45, 13, "SaveAndContinue", 3, true, "ذخیره و ادامه" },
                    { 44, 13, "SaveAndNew", 2, true, "ذخیره و جدید" }
                });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "مشاغل و گروه مشاغل");

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ActionName", "Code", "Name", "ShowInMenu" },
                values: new object[] { "JobDefine", "JobDefine", "تعریف مشاعل", false });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ActionName", "CategoryId", "Code", "ControllerName", "Name", "Priority", "ShowInMenu" },
                values: new object[] { "ShopGroups", 3, "ShopGroups", "Market", "گروه غرفات", 1, true });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ActionName", "Code", "Name", "Priority", "ShowInMenu" },
                values: new object[] { "ShopGroupDefine", "ShopGroupDefine", "تعریف گروه غرفات", 2, false });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ActionName", "Code", "Name", "Priority", "ShowInMenu" },
                values: new object[] { "Shops", "Shops", "غرفات", 3, true });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ActionName", "Code", "Name", "Priority", "ShowInMenu" },
                values: new object[] { "ShopDefine", "ShopDefine", "تعریف غرفه", 4, false });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuActionAccess",
                columns: new[] { "Id", "GroupId", "MenuActionId", "UserId" },
                values: new object[] { 44, null, 44, 1 });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuActionAccess",
                columns: new[] { "Id", "GroupId", "MenuActionId", "UserId" },
                values: new object[] { 45, null, 45, 1 });
        }
    }
}
