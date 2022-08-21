using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class AddAttendance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attendance",
                schema: "Mrk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentId = table.Column<int>(nullable: true),
                    ReserveId = table.Column<int>(nullable: true),
                    Date = table.Column<string>(maxLength: 10, nullable: true),
                    Time = table.Column<string>(maxLength: 8, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendance_Rent_RentId",
                        column: x => x.RentId,
                        principalSchema: "Mrk",
                        principalTable: "Rent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attendance_Reserve_ReserveId",
                        column: x => x.ReserveId,
                        principalSchema: "Mrk",
                        principalTable: "Reserve",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_RentId",
                schema: "Mrk",
                table: "Attendance",
                column: "RentId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_ReserveId",
                schema: "Mrk",
                table: "Attendance",
                column: "ReserveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendance",
                schema: "Mrk");
        }
    }
}
