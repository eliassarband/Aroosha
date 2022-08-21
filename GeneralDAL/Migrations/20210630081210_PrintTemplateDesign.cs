using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class PrintTemplateDesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuItem",
                columns: new[] { "Id", "ActionName", "CategoryId", "Code", "ControllerName", "DialogSize", "Name", "Priority", "ShowInMenu" },
                values: new object[] { 36, "PrintTemplateDesign", 2, "PrintTemplateDesign", "General", "large", "طراحی فرمت رسید اجاره و رزرو", 9, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Sec",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 36);
        }
    }
}
