using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class MarketStructureType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarketStructure_BasicInformation_BasicInformationId",
                schema: "Mrk",
                table: "MarketStructure");

            migrationBuilder.DropIndex(
                name: "IX_MarketStructure_BasicInformationId",
                schema: "Mrk",
                table: "MarketStructure");

            migrationBuilder.DropColumn(
                name: "BasicInformationId",
                schema: "Mrk",
                table: "MarketStructure");

            migrationBuilder.DropColumn(
                name: "TypeBasicInformationId",
                schema: "Mrk",
                table: "MarketStructure");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                schema: "Mrk",
                table: "MarketStructure",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MarketStructure_TypeId",
                schema: "Mrk",
                table: "MarketStructure",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MarketStructure_BasicInformation_TypeId",
                schema: "Mrk",
                table: "MarketStructure",
                column: "TypeId",
                principalSchema: "Gnr",
                principalTable: "BasicInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarketStructure_BasicInformation_TypeId",
                schema: "Mrk",
                table: "MarketStructure");

            migrationBuilder.DropIndex(
                name: "IX_MarketStructure_TypeId",
                schema: "Mrk",
                table: "MarketStructure");

            migrationBuilder.DropColumn(
                name: "TypeId",
                schema: "Mrk",
                table: "MarketStructure");

            migrationBuilder.AddColumn<int>(
                name: "BasicInformationId",
                schema: "Mrk",
                table: "MarketStructure",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeBasicInformationId",
                schema: "Mrk",
                table: "MarketStructure",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MarketStructure_BasicInformationId",
                schema: "Mrk",
                table: "MarketStructure",
                column: "BasicInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_MarketStructure_BasicInformation_BasicInformationId",
                schema: "Mrk",
                table: "MarketStructure",
                column: "BasicInformationId",
                principalSchema: "Gnr",
                principalTable: "BasicInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
