using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class Shops : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Length",
                schema: "Mrk",
                table: "Shop",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                schema: "Mrk",
                table: "Shop",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Width",
                schema: "Mrk",
                table: "Shop",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                schema: "Gnr",
                table: "BasicInformationCategory",
                columns: new[] { "Id", "Code", "Name", "RelatedCategoryId", "Viewable" },
                values: new object[] { 3, "ShopType", "نوع غرفه", null, true });

            migrationBuilder.InsertData(
                schema: "Gnr",
                table: "BasicInformation",
                columns: new[] { "Id", "Active", "AllowChange", "AllowDelete", "CategoryId", "Code", "IsDeleted", "Name", "Priority", "RelatedBasicInformationId", "StrCode" },
                values: new object[] { 301, true, false, false, 3, 1, false, "مغازه", 1, null, "S" });

            migrationBuilder.InsertData(
                schema: "Gnr",
                table: "BasicInformation",
                columns: new[] { "Id", "Active", "AllowChange", "AllowDelete", "CategoryId", "Code", "IsDeleted", "Name", "Priority", "RelatedBasicInformationId", "StrCode" },
                values: new object[] { 302, true, false, false, 3, 2, false, "کیوسک", 2, null, "K" });

            migrationBuilder.InsertData(
                schema: "Gnr",
                table: "BasicInformation",
                columns: new[] { "Id", "Active", "AllowChange", "AllowDelete", "CategoryId", "Code", "IsDeleted", "Name", "Priority", "RelatedBasicInformationId", "StrCode" },
                values: new object[] { 303, true, false, false, 3, 3, false, "کانکس", 3, null, "C" });

            migrationBuilder.CreateIndex(
                name: "IX_Shop_TypeId",
                schema: "Mrk",
                table: "Shop",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shop_BasicInformation_TypeId",
                schema: "Mrk",
                table: "Shop",
                column: "TypeId",
                principalSchema: "Gnr",
                principalTable: "BasicInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shop_BasicInformation_TypeId",
                schema: "Mrk",
                table: "Shop");

            migrationBuilder.DropIndex(
                name: "IX_Shop_TypeId",
                schema: "Mrk",
                table: "Shop");

            migrationBuilder.DeleteData(
                schema: "Gnr",
                table: "BasicInformation",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                schema: "Gnr",
                table: "BasicInformation",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                schema: "Gnr",
                table: "BasicInformation",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                schema: "Gnr",
                table: "BasicInformationCategory",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Length",
                schema: "Mrk",
                table: "Shop");

            migrationBuilder.DropColumn(
                name: "TypeId",
                schema: "Mrk",
                table: "Shop");

            migrationBuilder.DropColumn(
                name: "Width",
                schema: "Mrk",
                table: "Shop");
        }
    }
}
