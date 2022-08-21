using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class UserSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDefaultForm",
                schema: "Gnr",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    FormId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDefaultForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDefaultForm_MenuItem_FormId",
                        column: x => x.FormId,
                        principalSchema: "Sec",
                        principalTable: "MenuItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDefaultForm_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Sec",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSetting",
                schema: "Gnr",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    HomeTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSetting_BasicInformation_HomeTypeId",
                        column: x => x.HomeTypeId,
                        principalSchema: "Gnr",
                        principalTable: "BasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSetting_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Sec",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Gnr",
                table: "BasicInformationCategory",
                columns: new[] { "Id", "Code", "Name", "RelatedCategoryId", "Viewable" },
                values: new object[] { 5, "HomeType", "نوع فرم اصلی", null, false });

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 27,
                column: "Name",
                value: "ثبت اجاره دسته ای غرفات");

            migrationBuilder.InsertData(
                schema: "Gnr",
                table: "BasicInformation",
                columns: new[] { "Id", "Active", "AllowChange", "AllowDelete", "CategoryId", "Code", "IsDeleted", "Name", "Priority", "RelatedBasicInformationId", "StrCode" },
                values: new object[] { 501, true, false, false, 5, 1, false, "نمایش فرم ها به صورت Page", 1, null, "Page" });

            migrationBuilder.InsertData(
                schema: "Gnr",
                table: "BasicInformation",
                columns: new[] { "Id", "Active", "AllowChange", "AllowDelete", "CategoryId", "Code", "IsDeleted", "Name", "Priority", "RelatedBasicInformationId", "StrCode" },
                values: new object[] { 502, true, false, false, 5, 2, false, "نمایش فرم ها به صورت Window", 2, null, "Window" });

            migrationBuilder.CreateIndex(
                name: "IX_UserDefaultForm_FormId",
                schema: "Gnr",
                table: "UserDefaultForm",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDefaultForm_UserId",
                schema: "Gnr",
                table: "UserDefaultForm",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSetting_HomeTypeId",
                schema: "Gnr",
                table: "UserSetting",
                column: "HomeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSetting_UserId",
                schema: "Gnr",
                table: "UserSetting",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDefaultForm",
                schema: "Gnr");

            migrationBuilder.DropTable(
                name: "UserSetting",
                schema: "Gnr");

            migrationBuilder.DeleteData(
                schema: "Gnr",
                table: "BasicInformation",
                keyColumn: "Id",
                keyValue: 501);

            migrationBuilder.DeleteData(
                schema: "Gnr",
                table: "BasicInformation",
                keyColumn: "Id",
                keyValue: 502);

            migrationBuilder.DeleteData(
                schema: "Gnr",
                table: "BasicInformationCategory",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 27,
                column: "Name",
                value: "ثبت اجاره دسته ای غرفه");
        }
    }
}
