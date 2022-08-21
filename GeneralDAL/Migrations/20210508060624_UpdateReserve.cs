using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class UpdateReserve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiscountAmount",
                schema: "Mrk",
                table: "Reserve",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DiscountId",
                schema: "Mrk",
                table: "Reserve",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiscountPercent",
                schema: "Mrk",
                table: "Reserve",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TariffAmount",
                schema: "Mrk",
                table: "Reserve",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TariffId",
                schema: "Mrk",
                table: "Reserve",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 26,
                column: "DialogSize",
                value: "large");

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuItem",
                columns: new[] { "Id", "ActionName", "CategoryId", "Code", "ControllerName", "DialogSize", "Name", "Priority", "ShowInMenu" },
                values: new object[] { 33, "ReserveDefine", 4, "ReserveDefine", "Market", "large", "ثبت رزرو غرفه", 8, false });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuItem",
                columns: new[] { "Id", "ActionName", "CategoryId", "Code", "ControllerName", "DialogSize", "Name", "Priority", "ShowInMenu" },
                values: new object[] { 32, "Reserves", 4, "Reserves", "Market", "large", "رزروها", 7, true });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuAction",
                columns: new[] { "Id", "MenuItemId", "Name", "Priority", "ShowInToolbar", "Title" },
                values: new object[,]
                {
                    { 99, 32, "New", 1, true, "ثبت رزرو" },
                    { 100, 32, "Edit", 2, true, "ویرایش رزرو" },
                    { 101, 32, "Delete", 3, true, "حذف رزرو" },
                    { 102, 33, "Save", 1, true, "ذخیره" },
                    { 103, 33, "SaveAndNew", 2, true, "ذخیره و جدید" },
                    { 104, 33, "SaveAndContinue", 3, true, "ذخیره و ادامه" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserve_DiscountId",
                schema: "Mrk",
                table: "Reserve",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserve_TariffId",
                schema: "Mrk",
                table: "Reserve",
                column: "TariffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserve_Discount_DiscountId",
                schema: "Mrk",
                table: "Reserve",
                column: "DiscountId",
                principalSchema: "Mrk",
                principalTable: "Discount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserve_Tariff_TariffId",
                schema: "Mrk",
                table: "Reserve",
                column: "TariffId",
                principalSchema: "Mrk",
                principalTable: "Tariff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserve_Discount_DiscountId",
                schema: "Mrk",
                table: "Reserve");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserve_Tariff_TariffId",
                schema: "Mrk",
                table: "Reserve");

            migrationBuilder.DropIndex(
                name: "IX_Reserve_DiscountId",
                schema: "Mrk",
                table: "Reserve");

            migrationBuilder.DropIndex(
                name: "IX_Reserve_TariffId",
                schema: "Mrk",
                table: "Reserve");

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                schema: "Mrk",
                table: "Reserve");

            migrationBuilder.DropColumn(
                name: "DiscountId",
                schema: "Mrk",
                table: "Reserve");

            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                schema: "Mrk",
                table: "Reserve");

            migrationBuilder.DropColumn(
                name: "TariffAmount",
                schema: "Mrk",
                table: "Reserve");

            migrationBuilder.DropColumn(
                name: "TariffId",
                schema: "Mrk",
                table: "Reserve");

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 26,
                column: "DialogSize",
                value: "medium");
        }
    }
}
