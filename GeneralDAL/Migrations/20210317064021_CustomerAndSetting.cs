using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class CustomerAndSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountBalance",
                schema: "Mrk",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppAccountBalance",
                schema: "Mrk",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BirthCityId",
                schema: "Mrk",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BirthYear",
                schema: "Mrk",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Code",
                schema: "Mrk",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DebtCeiling",
                schema: "Mrk",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Mrk",
                table: "Customer",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                schema: "Mrk",
                table: "Customer",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Gender",
                schema: "Mrk",
                table: "Customer",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "HomeAddress",
                schema: "Mrk",
                table: "Customer",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomePhone",
                schema: "Mrk",
                table: "Customer",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdentityNumber",
                schema: "Mrk",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IssuanceCityId",
                schema: "Mrk",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                schema: "Mrk",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalPaymentsAmount",
                schema: "Mrk",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalRentsAmount",
                schema: "Mrk",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "WorkAddress",
                schema: "Mrk",
                table: "Customer",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkPhone",
                schema: "Mrk",
                table: "Customer",
                maxLength: 11,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Setting",
                schema: "Gnr",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyName = table.Column<string>(maxLength: 200, nullable: true),
                    KeyValue = table.Column<string>(maxLength: 2000, nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Gnr",
                table: "Setting",
                columns: new[] { "Id", "Active", "KeyName", "KeyValue" },
                values: new object[] { 1, true, "DefaultDebtCeiling", "0" });

            migrationBuilder.InsertData(
                schema: "Gnr",
                table: "Setting",
                columns: new[] { "Id", "Active", "KeyName", "KeyValue" },
                values: new object[] { 2, true, "MinCardCredit", "0" });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_BirthCityId",
                schema: "Mrk",
                table: "Customer",
                column: "BirthCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_IssuanceCityId",
                schema: "Mrk",
                table: "Customer",
                column: "IssuanceCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_JobId",
                schema: "Mrk",
                table: "Customer",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Region_BirthCityId",
                schema: "Mrk",
                table: "Customer",
                column: "BirthCityId",
                principalSchema: "Gnr",
                principalTable: "Region",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Region_IssuanceCityId",
                schema: "Mrk",
                table: "Customer",
                column: "IssuanceCityId",
                principalSchema: "Gnr",
                principalTable: "Region",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Job_JobId",
                schema: "Mrk",
                table: "Customer",
                column: "JobId",
                principalSchema: "Gnr",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Region_BirthCityId",
                schema: "Mrk",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Region_IssuanceCityId",
                schema: "Mrk",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Job_JobId",
                schema: "Mrk",
                table: "Customer");

            migrationBuilder.DropTable(
                name: "Setting",
                schema: "Gnr");

            migrationBuilder.DropIndex(
                name: "IX_Customer_BirthCityId",
                schema: "Mrk",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_IssuanceCityId",
                schema: "Mrk",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_JobId",
                schema: "Mrk",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "AccountBalance",
                schema: "Mrk",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "AppAccountBalance",
                schema: "Mrk",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "BirthCityId",
                schema: "Mrk",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "BirthYear",
                schema: "Mrk",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "Mrk",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "DebtCeiling",
                schema: "Mrk",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Mrk",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "FatherName",
                schema: "Mrk",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Gender",
                schema: "Mrk",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "HomeAddress",
                schema: "Mrk",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "HomePhone",
                schema: "Mrk",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "IdentityNumber",
                schema: "Mrk",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "IssuanceCityId",
                schema: "Mrk",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "JobId",
                schema: "Mrk",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "TotalPaymentsAmount",
                schema: "Mrk",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "TotalRentsAmount",
                schema: "Mrk",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "WorkAddress",
                schema: "Mrk",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "WorkPhone",
                schema: "Mrk",
                table: "Customer");
        }
    }
}
