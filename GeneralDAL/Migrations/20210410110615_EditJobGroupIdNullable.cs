using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class EditJobGroupIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_JobGroup_JobGroupId",
                schema: "Mrk",
                table: "Customer");

            migrationBuilder.AlterColumn<int>(
                name: "JobGroupId",
                schema: "Mrk",
                table: "Customer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_JobGroup_JobGroupId",
                schema: "Mrk",
                table: "Customer",
                column: "JobGroupId",
                principalSchema: "Gnr",
                principalTable: "JobGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_JobGroup_JobGroupId",
                schema: "Mrk",
                table: "Customer");

            migrationBuilder.AlterColumn<int>(
                name: "JobGroupId",
                schema: "Mrk",
                table: "Customer",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_JobGroup_JobGroupId",
                schema: "Mrk",
                table: "Customer",
                column: "JobGroupId",
                principalSchema: "Gnr",
                principalTable: "JobGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
