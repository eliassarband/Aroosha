using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class Discount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiscountAmount",
                schema: "Mrk",
                table: "Rent",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DiscountId",
                schema: "Mrk",
                table: "Rent",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TariffAmount",
                schema: "Mrk",
                table: "Rent",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TariffId",
                schema: "Mrk",
                table: "Rent",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Discount",
                schema: "Mrk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    DefaultPercent = table.Column<int>(nullable: false),
                    DefaultPrice = table.Column<int>(nullable: false),
                    StartDate = table.Column<string>(maxLength: 10, nullable: true),
                    EndDate = table.Column<string>(maxLength: 10, nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rent_DiscountId",
                schema: "Mrk",
                table: "Rent",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Rent_TariffId",
                schema: "Mrk",
                table: "Rent",
                column: "TariffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rent_Discount_DiscountId",
                schema: "Mrk",
                table: "Rent",
                column: "DiscountId",
                principalSchema: "Mrk",
                principalTable: "Discount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rent_Tariff_TariffId",
                schema: "Mrk",
                table: "Rent",
                column: "TariffId",
                principalSchema: "Mrk",
                principalTable: "Tariff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rent_Discount_DiscountId",
                schema: "Mrk",
                table: "Rent");

            migrationBuilder.DropForeignKey(
                name: "FK_Rent_Tariff_TariffId",
                schema: "Mrk",
                table: "Rent");

            migrationBuilder.DropTable(
                name: "Discount",
                schema: "Mrk");

            migrationBuilder.DropIndex(
                name: "IX_Rent_DiscountId",
                schema: "Mrk",
                table: "Rent");

            migrationBuilder.DropIndex(
                name: "IX_Rent_TariffId",
                schema: "Mrk",
                table: "Rent");

            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                schema: "Mrk",
                table: "Rent");

            migrationBuilder.DropColumn(
                name: "DiscountId",
                schema: "Mrk",
                table: "Rent");

            migrationBuilder.DropColumn(
                name: "TariffAmount",
                schema: "Mrk",
                table: "Rent");

            migrationBuilder.DropColumn(
                name: "TariffId",
                schema: "Mrk",
                table: "Rent");
        }
    }
}
