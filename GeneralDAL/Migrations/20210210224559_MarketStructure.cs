using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class MarketStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Mrk");

            migrationBuilder.CreateTable(
                name: "MarketStructure",
                schema: "Mrk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: false),
                    TypeBasicInformationId = table.Column<int>(nullable: false),
                    BasicInformationId = table.Column<int>(nullable: true),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    StructureAddress = table.Column<string>(maxLength: 1000, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketStructure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketStructure_BasicInformation_BasicInformationId",
                        column: x => x.BasicInformationId,
                        principalSchema: "Gnr",
                        principalTable: "BasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarketStructure_MarketStructure_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Mrk",
                        principalTable: "MarketStructure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarketStructure_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "Gnr",
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopGroup",
                schema: "Mrk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shop",
                schema: "Mrk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    ShopGroupId = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: false),
                    MarketStructureId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shop_MarketStructure_MarketStructureId",
                        column: x => x.MarketStructureId,
                        principalSchema: "Mrk",
                        principalTable: "MarketStructure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shop_ShopGroup_ShopGroupId",
                        column: x => x.ShopGroupId,
                        principalSchema: "Mrk",
                        principalTable: "ShopGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shop_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "Gnr",
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Gnr",
                table: "BasicInformationCategory",
                columns: new[] { "Id", "Code", "Name", "RelatedCategoryId", "Viewable" },
                values: new object[] { 2, "MarketStructure", "ساختار بازار", null, false });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuItem",
                columns: new[] { "Id", "ActionName", "CategoryId", "Code", "ControllerName", "DialogSize", "Name", "Priority", "ShowInMenu" },
                values: new object[] { 15, "MarketStructures", 3, "MarketStructures", "Market", "medium", "مدیریت ساختار بازارها", 5, true });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuItem",
                columns: new[] { "Id", "ActionName", "CategoryId", "Code", "ControllerName", "DialogSize", "Name", "Priority", "ShowInMenu" },
                values: new object[] { 16, "MarketStructureDefine", 3, "MarketStructureDefine", "Market", "medium", "ایجاد و ویرایش ساختار بازار", 6, false });

            migrationBuilder.InsertData(
                schema: "Gnr",
                table: "BasicInformation",
                columns: new[] { "Id", "Active", "AllowChange", "AllowDelete", "CategoryId", "Code", "IsDeleted", "Name", "Priority", "RelatedBasicInformationId", "StrCode" },
                values: new object[,]
                {
                    { 201, true, false, false, 2, 1, false, "فاز", 1, null, "Phase" },
                    { 202, true, false, false, 2, 2, false, "زون", 2, null, "Zone" },
                    { 203, true, false, false, 2, 3, false, "راهرو", 3, null, "Corridor" },
                    { 204, true, false, false, 2, 4, false, "غرفه", 4, null, "Shop" }
                });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuAccess",
                columns: new[] { "Id", "GroupId", "MenuItemId", "UserId" },
                values: new object[,]
                {
                    { 15, null, 15, 1 },
                    { 16, null, 16, 1 }
                });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuAction",
                columns: new[] { "Id", "MenuItemId", "Name", "Priority", "ShowInToolbar", "Title" },
                values: new object[,]
                {
                    { 47, 15, "New", 1, true, "تعریف ساختار جدید" },
                    { 48, 15, "Edit", 2, true, "ویرایش ساختار" },
                    { 49, 15, "Delete", 3, true, "حذف ساختار" },
                    { 50, 16, "Save", 1, true, "ذخیره" },
                    { 51, 16, "SaveAndNew", 2, true, "ذخیره و جدید" },
                    { 52, 16, "SaveAndContinue", 3, true, "ذخیره و ادامه" }
                });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuActionAccess",
                columns: new[] { "Id", "GroupId", "MenuActionId", "UserId" },
                values: new object[,]
                {
                    { 47, null, 47, 1 },
                    { 48, null, 48, 1 },
                    { 49, null, 49, 1 },
                    { 50, null, 50, 1 },
                    { 51, null, 51, 1 },
                    { 52, null, 52, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarketStructure_BasicInformationId",
                schema: "Mrk",
                table: "MarketStructure",
                column: "BasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketStructure_ParentId",
                schema: "Mrk",
                table: "MarketStructure",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketStructure_TenantId",
                schema: "Mrk",
                table: "MarketStructure",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_MarketStructureId",
                schema: "Mrk",
                table: "Shop",
                column: "MarketStructureId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_ShopGroupId",
                schema: "Mrk",
                table: "Shop",
                column: "ShopGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_TenantId",
                schema: "Mrk",
                table: "Shop",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shop",
                schema: "Mrk");

            migrationBuilder.DropTable(
                name: "MarketStructure",
                schema: "Mrk");

            migrationBuilder.DropTable(
                name: "ShopGroup",
                schema: "Mrk");

            migrationBuilder.DeleteData(
                schema: "Gnr",
                table: "BasicInformation",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                schema: "Gnr",
                table: "BasicInformation",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                schema: "Gnr",
                table: "BasicInformation",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                schema: "Gnr",
                table: "BasicInformation",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAccess",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAccess",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuActionAccess",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                schema: "Gnr",
                table: "BasicInformationCategory",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuAction",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 16);
        }
    }
}
