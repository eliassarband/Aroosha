using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class UpdateShopGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shop_ShopGroup_ShopGroupId",
                schema: "Mrk",
                table: "Shop");

            migrationBuilder.AlterColumn<int>(
                name: "ShopGroupId",
                schema: "Mrk",
                table: "Shop",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Shop_ShopGroup_ShopGroupId",
                schema: "Mrk",
                table: "Shop",
                column: "ShopGroupId",
                principalSchema: "Mrk",
                principalTable: "ShopGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shop_ShopGroup_ShopGroupId",
                schema: "Mrk",
                table: "Shop");

            migrationBuilder.AlterColumn<int>(
                name: "ShopGroupId",
                schema: "Mrk",
                table: "Shop",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Shop_ShopGroup_ShopGroupId",
                schema: "Mrk",
                table: "Shop",
                column: "ShopGroupId",
                principalSchema: "Mrk",
                principalTable: "ShopGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
