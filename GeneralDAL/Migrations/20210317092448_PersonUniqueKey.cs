using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class PersonUniqueKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StrCode",
                schema: "Gnr",
                table: "Person",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Person_Code",
                schema: "Gnr",
                table: "Person",
                column: "Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Person_StrCode",
                schema: "Gnr",
                table: "Person",
                column: "StrCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Person_Code",
                schema: "Gnr",
                table: "Person");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Person_StrCode",
                schema: "Gnr",
                table: "Person");

            migrationBuilder.AlterColumn<string>(
                name: "StrCode",
                schema: "Gnr",
                table: "Person",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);
        }
    }
}
