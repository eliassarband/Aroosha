using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class Rent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rent",
                schema: "Mrk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(maxLength: 10, nullable: true),
                    CustomerId = table.Column<int>(nullable: true),
                    MarketScheduleDetailId = table.Column<int>(nullable: true),
                    ShopId = table.Column<int>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    Paid = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rent_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Mrk",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rent_MarketScheduleDetail_MarketScheduleDetailId",
                        column: x => x.MarketScheduleDetailId,
                        principalSchema: "Mrk",
                        principalTable: "MarketScheduleDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rent_Shop_ShopId",
                        column: x => x.ShopId,
                        principalSchema: "Mrk",
                        principalTable: "Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reserve",
                schema: "Mrk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(maxLength: 10, nullable: true),
                    CustomerId = table.Column<int>(nullable: true),
                    MarketScheduleDetailId = table.Column<int>(nullable: true),
                    ShopId = table.Column<int>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    Paid = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserve", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserve_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Mrk",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserve_MarketScheduleDetail_MarketScheduleDetailId",
                        column: x => x.MarketScheduleDetailId,
                        principalSchema: "Mrk",
                        principalTable: "MarketScheduleDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserve_Shop_ShopId",
                        column: x => x.ShopId,
                        principalSchema: "Mrk",
                        principalTable: "Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                schema: "Mrk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(maxLength: 10, nullable: true),
                    RentId = table.Column<int>(nullable: true),
                    ReserveId = table.Column<int>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Rent_RentId",
                        column: x => x.RentId,
                        principalSchema: "Mrk",
                        principalTable: "Rent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_Reserve_ReserveId",
                        column: x => x.ReserveId,
                        principalSchema: "Mrk",
                        principalTable: "Reserve",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuAction",
                columns: new[] { "Id", "MenuItemId", "Name", "Priority", "ShowInToolbar", "Title" },
                values: new object[,]
                {
                    { 85, 14, "NewRent", 4, true, "ثبت اجاره" },
                    { 86, 20, "NewRent", 6, true, "ثبت اجاره" }
                });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuItem",
                columns: new[] { "Id", "ActionName", "CategoryId", "Code", "ControllerName", "DialogSize", "Name", "Priority", "ShowInMenu" },
                values: new object[,]
                {
                    { 25, "Rents", 4, "Tariffs", "Market", "large", "اجاره ها", 3, true },
                    { 26, "RentDefine", 4, "TariffDefine", "Market", "medium", "ثبت اجاره غرفه", 4, true }
                });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuAction",
                columns: new[] { "Id", "MenuItemId", "Name", "Priority", "ShowInToolbar", "Title" },
                values: new object[,]
                {
                    { 79, 25, "New", 1, true, "ثبت اجاره" },
                    { 80, 25, "Edit", 2, true, "ویرایش اجاره" },
                    { 81, 25, "Delete", 3, true, "حذف اجاره" },
                    { 82, 26, "Save", 1, true, "ذخیره" },
                    { 83, 26, "SaveAndNew", 2, true, "ذخیره و جدید" },
                    { 84, 26, "SaveAndContinue", 3, true, "ذخیره و ادامه" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_RentId",
                schema: "Mrk",
                table: "Payment",
                column: "RentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ReserveId",
                schema: "Mrk",
                table: "Payment",
                column: "ReserveId");

            migrationBuilder.CreateIndex(
                name: "IX_Rent_CustomerId",
                schema: "Mrk",
                table: "Rent",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rent_MarketScheduleDetailId",
                schema: "Mrk",
                table: "Rent",
                column: "MarketScheduleDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Rent_ShopId",
                schema: "Mrk",
                table: "Rent",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserve_CustomerId",
                schema: "Mrk",
                table: "Reserve",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserve_MarketScheduleDetailId",
                schema: "Mrk",
                table: "Reserve",
                column: "MarketScheduleDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserve_ShopId",
                schema: "Mrk",
                table: "Reserve",
                column: "ShopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment",
                schema: "Mrk");

            migrationBuilder.DropTable(
                name: "Rent",
                schema: "Mrk");

            migrationBuilder.DropTable(
                name: "Reserve",
                schema: "Mrk");

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 26);
        }
    }
}
