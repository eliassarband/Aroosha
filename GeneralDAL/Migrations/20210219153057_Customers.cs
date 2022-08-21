using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class Customers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "Mrk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    NationalCode = table.Column<string>(maxLength: 10, nullable: true),
                    MobileNumber = table.Column<string>(maxLength: 11, nullable: true),
                    JobGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_JobGroup_JobGroupId",
                        column: x => x.JobGroupId,
                        principalSchema: "Gnr",
                        principalTable: "JobGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCard",
                schema: "Mrk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    CardCode = table.Column<string>(maxLength: 20, nullable: true),
                    StartDate = table.Column<string>(maxLength: 10, nullable: true),
                    EndDate = table.Column<string>(maxLength: 10, nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerCard_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Mrk",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuCategory",
                columns: new[] { "Id", "Name", "Priority", "ShowInMenu" },
                values: new object[] { 5, "مدیریت مشتریان", 5, true });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuItem",
                columns: new[] { "Id", "ActionName", "CategoryId", "Code", "ControllerName", "DialogSize", "Name", "Priority", "ShowInMenu" },
                values: new object[] { 19, "Customers", 5, "Customers", "Market", "large", "مشتریان", 1, true });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuItem",
                columns: new[] { "Id", "ActionName", "CategoryId", "Code", "ControllerName", "DialogSize", "Name", "Priority", "ShowInMenu" },
                values: new object[] { 20, "CustomerDefine", 5, "CustomerDefine", "Market", "medium", "تعریف مشتریان", 2, false });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuItem",
                columns: new[] { "Id", "ActionName", "CategoryId", "Code", "ControllerName", "DialogSize", "Name", "Priority", "ShowInMenu" },
                values: new object[] { 21, "CustomerCardDefine", 5, "CustomerCardDefine", "Market", "medium", "تعریف کارت عضویت", 3, false });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuAccess",
                columns: new[] { "Id", "GroupId", "MenuItemId", "UserId" },
                values: new object[,]
                {
                    { 19, null, 19, 1 },
                    { 20, null, 20, 1 },
                    { 21, null, 21, 1 }
                });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuAction",
                columns: new[] { "Id", "MenuItemId", "Name", "Priority", "ShowInToolbar", "Title" },
                values: new object[,]
                {
                    { 59, 19, "New", 1, true, "تعریف مشتری" },
                    { 60, 19, "Edit", 2, true, "ویرایش مشتری" },
                    { 61, 19, "Delete", 3, true, "حذف مشتری" },
                    { 62, 20, "Save", 1, true, "ذخیره" },
                    { 63, 20, "SaveAndNew", 2, true, "ذخیره و جدید" },
                    { 64, 20, "SaveAndContinue", 3, true, "ذخیره و ادامه" },
                    { 65, 20, "CardDefine", 4, true, "تعریف کارت عضویت" },
                    { 66, 21, "Save", 1, true, "ذخیره" },
                    { 67, 21, "SaveAndNew", 2, true, "ذخیره و جدید" },
                    { 68, 21, "SaveAndContinue", 3, true, "ذخیره و ادامه" }
                });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuActionAccess",
                columns: new[] { "Id", "GroupId", "MenuActionId", "UserId" },
                values: new object[,]
                {
                    { 59, null, 59, 1 },
                    { 60, null, 60, 1 },
                    { 61, null, 61, 1 },
                    { 62, null, 62, 1 },
                    { 63, null, 63, 1 },
                    { 64, null, 64, 1 },
                    { 65, null, 65, 1 },
                    { 66, null, 66, 1 },
                    { 67, null, 67, 1 },
                    { 68, null, 68, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_JobGroupId",
                schema: "Mrk",
                table: "Customer",
                column: "JobGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCard_CustomerId",
                schema: "Mrk",
                table: "CustomerCard",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerCard",
                schema: "Mrk");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "Mrk");

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAccess",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAccess",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAccess",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuCategory",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
