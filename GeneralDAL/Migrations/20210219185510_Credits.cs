using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class Credits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Credit",
                schema: "Mrk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    Date = table.Column<string>(maxLength: 10, nullable: true),
                    PaymentTypeId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Type = table.Column<bool>(nullable: false),
                    ReceiptNumber = table.Column<string>(maxLength: 20, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credit_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Mrk",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Credit_BasicInformation_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalSchema: "Gnr",
                        principalTable: "BasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Gnr",
                table: "BasicInformationCategory",
                columns: new[] { "Id", "Code", "Name", "RelatedCategoryId", "Viewable" },
                values: new object[] { 4, "PaymentType", "نوع پرداخت", null, false });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuAction",
                columns: new[] { "Id", "MenuItemId", "Name", "Priority", "ShowInToolbar", "Title" },
                values: new object[] { 72, 20, "Credits", 5, true, "شارژهای اعتبار" });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuItem",
                columns: new[] { "Id", "ActionName", "CategoryId", "Code", "ControllerName", "DialogSize", "Name", "Priority", "ShowInMenu" },
                values: new object[,]
                {
                    { 23, "Credits", 5, "Credits", "Market", "large", "شارژهای اعتبار", 5, true },
                    { 24, "CreditDefine", 5, "CreditDefine", "Market", "medium", "ثبت شارژ اعتبار", 6, false }
                });

            migrationBuilder.InsertData(
                schema: "Gnr",
                table: "BasicInformation",
                columns: new[] { "Id", "Active", "AllowChange", "AllowDelete", "CategoryId", "Code", "IsDeleted", "Name", "Priority", "RelatedBasicInformationId", "StrCode" },
                values: new object[,]
                {
                    { 401, true, false, false, 4, 1, false, "نقدی", 1, null, "Cash" },
                    { 402, true, false, false, 4, 2, false, "کارتخوان", 2, null, "PCPos" }
                });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuAccess",
                columns: new[] { "Id", "GroupId", "MenuItemId", "UserId" },
                values: new object[,]
                {
                    { 23, null, 23, 1 },
                    { 24, null, 24, 1 }
                });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuAction",
                columns: new[] { "Id", "MenuItemId", "Name", "Priority", "ShowInToolbar", "Title" },
                values: new object[,]
                {
                    { 73, 23, "New", 1, true, "تعریف شارژ" },
                    { 74, 23, "Edit", 2, true, "ویرایش شارژ" },
                    { 75, 23, "Delete", 3, true, "حذف شارژ" },
                    { 76, 24, "Save", 1, true, "ذخیره" },
                    { 77, 24, "SaveAndNew", 2, true, "ذخیره و جدید" },
                    { 78, 24, "SaveAndContinue", 3, true, "ذخیره و ادامه" }
                });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuActionAccess",
                columns: new[] { "Id", "GroupId", "MenuActionId", "UserId" },
                values: new object[] { 72, null, 72, 1 });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuActionAccess",
                columns: new[] { "Id", "GroupId", "MenuActionId", "UserId" },
                values: new object[,]
                {
                    { 73, null, 73, 1 },
                    { 74, null, 74, 1 },
                    { 75, null, 75, 1 },
                    { 76, null, 76, 1 },
                    { 77, null, 77, 1 },
                    { 78, null, 78, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Credit_CustomerId",
                schema: "Mrk",
                table: "Credit",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Credit_PaymentTypeId",
                schema: "Mrk",
                table: "Credit",
                column: "PaymentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Credit",
                schema: "Mrk");

            migrationBuilder.DeleteData(
                schema: "Gnr",
                table: "BasicInformation",
                keyColumn: "Id",
                keyValue: 401);

            migrationBuilder.DeleteData(
                schema: "Gnr",
                table: "BasicInformation",
                keyColumn: "Id",
                keyValue: 402);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAccess",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAccess",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                schema: "Gnr",
                table: "BasicInformationCategory",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 24);
        }
    }
}
