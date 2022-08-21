using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class UserAndGroupAccess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuAccess_User_UserId",
                schema: "Sec",
                table: "MenuAccess");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuActionAccess_User_UserId",
                schema: "Sec",
                table: "MenuActionAccess");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "Sec",
                table: "MenuActionAccess",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                schema: "Sec",
                table: "MenuActionAccess",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "Sec",
                table: "MenuAccess",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                schema: "Sec",
                table: "MenuAccess",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 12,
                column: "Priority",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 13,
                column: "Priority",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 14,
                column: "Priority",
                value: 2);

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuAction",
                columns: new[] { "Id", "MenuItemId", "Name", "Priority", "ShowInToolbar", "Title" },
                values: new object[,]
                {
                    { 15, 2, "UserAccess", 4, true, "مدیریت دسترسی کاربران" },
                    { 16, 4, "GroupAccess", 4, true, "مدیریت دسترسی گروه های کاربری" }
                });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuItem",
                columns: new[] { "Id", "ActionName", "CategoryId", "Code", "ControllerName", "DialogSize", "Name", "Priority", "ShowInMenu" },
                values: new object[,]
                {
                    { 5, "UserAccess", 1, "UserAccess", "Security", "large", "مدیریت دسترسی کاربران", 5, false },
                    { 6, "GroupAccess", 1, "GroupAccess", "Security", "large", "مدیریت دسترسی گروه های کاربری", 6, false }
                });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuAccess",
                columns: new[] { "Id", "GroupId", "MenuItemId", "UserId" },
                values: new object[,]
                {
                    { 5, null, 5, 1 },
                    { 6, null, 6, 1 }
                });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuAction",
                columns: new[] { "Id", "MenuItemId", "Name", "Priority", "ShowInToolbar", "Title" },
                values: new object[,]
                {
                    { 17, 5, "Save", 1, true, "ذخیره" },
                    { 18, 6, "Save", 1, true, "ذخیره" }
                });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuActionAccess",
                columns: new[] { "Id", "GroupId", "MenuActionId", "UserId" },
                values: new object[,]
                {
                    { 15, null, 15, 1 },
                    { 16, null, 16, 1 }
                });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuActionAccess",
                columns: new[] { "Id", "GroupId", "MenuActionId", "UserId" },
                values: new object[] { 17, null, 17, 1 });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuActionAccess",
                columns: new[] { "Id", "GroupId", "MenuActionId", "UserId" },
                values: new object[] { 18, null, 18, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_MenuActionAccess_GroupId",
                schema: "Sec",
                table: "MenuActionAccess",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuAccess_GroupId",
                schema: "Sec",
                table: "MenuAccess",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuAccess_Group_GroupId",
                schema: "Sec",
                table: "MenuAccess",
                column: "GroupId",
                principalSchema: "Sec",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuAccess_User_UserId",
                schema: "Sec",
                table: "MenuAccess",
                column: "UserId",
                principalSchema: "Sec",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuActionAccess_Group_GroupId",
                schema: "Sec",
                table: "MenuActionAccess",
                column: "GroupId",
                principalSchema: "Sec",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuActionAccess_User_UserId",
                schema: "Sec",
                table: "MenuActionAccess",
                column: "UserId",
                principalSchema: "Sec",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuAccess_Group_GroupId",
                schema: "Sec",
                table: "MenuAccess");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuAccess_User_UserId",
                schema: "Sec",
                table: "MenuAccess");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuActionAccess_Group_GroupId",
                schema: "Sec",
                table: "MenuActionAccess");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuActionAccess_User_UserId",
                schema: "Sec",
                table: "MenuActionAccess");

            migrationBuilder.DropIndex(
                name: "IX_MenuActionAccess_GroupId",
                schema: "Sec",
                table: "MenuActionAccess");

            migrationBuilder.DropIndex(
                name: "IX_MenuAccess_GroupId",
                schema: "Sec",
                table: "MenuAccess");

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAccess",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAccess",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "GroupId",
                schema: "Sec",
                table: "MenuActionAccess");

            migrationBuilder.DropColumn(
                name: "GroupId",
                schema: "Sec",
                table: "MenuAccess");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "Sec",
                table: "MenuActionAccess",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "Sec",
                table: "MenuAccess",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 12,
                column: "Priority",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 13,
                column: "Priority",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 14,
                column: "Priority",
                value: 3);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuAccess_User_UserId",
                schema: "Sec",
                table: "MenuAccess",
                column: "UserId",
                principalSchema: "Sec",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuActionAccess_User_UserId",
                schema: "Sec",
                table: "MenuActionAccess",
                column: "UserId",
                principalSchema: "Sec",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
