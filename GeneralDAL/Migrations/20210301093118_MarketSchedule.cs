using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class MarketSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarketSchedule",
                schema: "Mrk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarketId = table.Column<int>(nullable: false),
                    StartDate = table.Column<string>(maxLength: 10, nullable: true),
                    EndDate = table.Column<string>(maxLength: 10, nullable: true),
                    WeekDay = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketSchedule_Tenant_MarketId",
                        column: x => x.MarketId,
                        principalSchema: "Gnr",
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketScheduleDetail",
                schema: "Mrk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarketScheduleId = table.Column<int>(nullable: false),
                    Date = table.Column<string>(maxLength: 10, nullable: true),
                    WeekDay = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketScheduleDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketScheduleDetail_MarketSchedule_MarketScheduleId",
                        column: x => x.MarketScheduleId,
                        principalSchema: "Mrk",
                        principalTable: "MarketSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarketSchedule_MarketId",
                schema: "Mrk",
                table: "MarketSchedule",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketScheduleDetail_MarketScheduleId",
                schema: "Mrk",
                table: "MarketScheduleDetail",
                column: "MarketScheduleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarketScheduleDetail",
                schema: "Mrk");

            migrationBuilder.DropTable(
                name: "MarketSchedule",
                schema: "Mrk");
        }
    }
}
